# WCF as a legacy technology (Use Grpc instead!)

## Quick reminder! 

### DataContract & DataMember Vs Serializable attributes
For a complex type like Customer, Employee, Student to be serialized, the complex type can either be decorated with 
1. SerializableAttribute or
2. DataContractAttribute

DataContract or DataMember attributes are explicitly use!, Data Contract Serializer will serialize all public properties of complex type in an alphabetical order. By default private field and properties are not serialized unless if it explicitly specified with DataMember (in such case we have to specify also DataContract for complex type). 

With [Serializable] attribute we don't have explicit control on what fields to include and exclude in serialized data.

1. Using DataContractAttribute, we can define an XML namespace for the data
2. Using DataMemberAttribute, w can
    a) Define Name, Order, and whether if a property or field IsRequired
    b) Also, serialize private fields and properties


### using Known types with inheritance
For classes related by inheritance, the wcf service generally accepts and returns the base type. If we expect the service to accept and return inherited types, then we use KnownType attribute.

```
	[KnownType(typeof(FullTimeEmployee))]
    [KnownType(typeof(PartTimeEmployee))]
    [DataContract(Namespace = "http://mycompany.com/Employee")]
    public class Employee
    {
	[DataMember(Order = 1, IsRequired=true)]
    public int Id { get; set; }
	....
	
```
we can also specify the Known types in the config

```
<system.runtime.serialization>
  <dataContractSerializer>
    <declaredTypes>
      <add type="EmployeeService.Employee, EmployeeService, Version=1.0.0.0, 
            Culture=Neutral, PublicKeyToken=null">
        <knownType type="EmployeeService.FullTimeEmployee, EmployeeService, 
                    Version=1.0.0.0, Culture=Neutral, PublicKeyToken=null"/>
        <knownType type="EmployeeService.PartTimeEmployee, EmployeeService, 
                    Version=1.0.0.0, Culture=Neutral, PublicKeyToken=null"/>
      </add>
    </declaredTypes>
  </dataContractSerializer>
</system.runtime.serialization>
```

### Enable tracing and message logging in wcf

1. Right click on the config file and select "Edit WCF Configuration" option from the context menu. If we don't see this option, click on Tools menu item and then selecct WCF Configuration Editor and then point to the config file. 
2. Select Diagnostics folder
3. Click on Enable Log Auto Flush link.
4. Then click on Enable Message Logging link. This should automatically add file, to which messages will be logged. To enable tracing click on Enable Tracing link.
5. Expand Diagnostics folder on the left hand side
6. Select Message Logging item that is present under Diagnostics folder. On the right hand side set LogEntireMessage option to true.
7. Close Microsoft Service Configuration Editor tool. This will ask we to Save Changes. Click Yes.


### MessageContract vs DataContract

Data Contracts have very limited control over the SOAP XML request and response messages that are generated. 

Few examples of when Message Contracts 
1. Include custom data in the SOAP header. In general SOAP headers are used to pass user credentials, license keys, session keys etc.
2. Change the name of the wrapper element in the SOAP message or to remove it altogether.


**Example**
Decorate the class with MessageContract attribute, and then use that class as an operation contract parameter or return type. 
It has the following parameters:
1. IsWrapped
2. WrapperName
3. WrapperNamespace
4. ProtectionLevel

**MessageHeader** attribute is applied on a property of the class that we want to include in the **SOAP header**. 
It has the following parameters:
1. Name
2. Namespace
3. ProtectionLevel
4. Actor
5. MustUnderstand
6. Relay

**MessageBodyMember** attribute is applied on a property of the class that we want to include in the SOAP body section (e.g request class). It has the following parameters:
1. Name
2. Namespace
3. Order
4. ProtectionLevel

>> In general, we use MessageContract only if there is a reason to adjust the structure of the soap XML message.


### Backward compatible WCF contract changes
After a WCF service is deployed, the WSDL document should not be changed to break the existing clients, i.e. the clients have already generated proxy classes and relevant configuration to interact with the service.  Any changes should be done to support backward compatibility.

The DataContractSerializer (i.e. the default engine for serialization in WCF) allows missing, non-required data and ignores newly added data for service contracts, data contracts & message contracts.

Removing an existing operation contracts would throw an exception by the service  if they call upon missing operation contract.

### ExtensionDataObject
We use IExtensibleDataObject to preserve unkown elements during serialization and deserialization of DataContracts. On the service side, at the time of deserialization the unknown elements from the client are stored in ExtensionDataObject. To send data to the client, the service has to serialize data into XML. During this serialization process the data from ExtensionDataObject is serialized into XML as it was provided at the time of service call.

**Denial of Service attack (DoS)**

IExtensibleDataObject interface has a risk of DoS attack. Since, the extension data is stored in memory, the attacker may flood the server with requests that contains large number of unknown elements which can lead to system out of memory and DoS.

**turn off IExtensibleDataObject feature**

IExtensibleDataObject feature is turned off => the deserializer will not populate the ExtensionData property.

```
<behaviors>
  <serviceBehaviors>
    <behavior name="ignoreExtensionData">
      <dataContractSerializer ignoreExtensionDataObject="true"/>
    </behavior>
  </serviceBehaviors>
</behaviors>
```
or

```
[ServiceBehavior(IgnoreExtensionDataObject = true)]
public class EmployeeService : IEmployeeService
```


### Exception handling & Soap faults

What happens when an exception occurs in a WCF service?/what is a SOAP fault?/How are WCF service exceptions reported to client applications?

When an exception occurs in a WCF service, the service serializes the exception into a SOAP fault, and then sends the SOAP fault to the client. 
for **security reasons**, a **generic SOAP fault** is sent to the client and **Unhandled exception details** are not included in **SOAP faults** by default.


To include exception details in SOAP faults, enable IncludeExceptionDetailInFaults setting

```
<behaviors>
  <serviceBehaviors>
    <behavior name="inculdeExceptionDetails">
      <serviceDebug includeExceptionDetailInFaults="true"/>
    </behavior>
  </serviceBehaviors>
</behaviors>
```

Or 

```
[ServiceBehavior(IncludeExceptionDetailInFaults=true)]
public class CalculatorService : ICalculatorService
{
    public int Divide(int Numerator, int Denominator)
    {
        return Numerator / Denominator;
    }
}
```



An unhandled exception in the WCF service causes the communication channel to fault and the session will be lost. Once the communication channel is in faulted state we cannot use the same instance of the proxy class any more. We have to create a new instance of the proxy class.


- **BasicHttpBinding** (no sessions): when an unhandled exception occurs, it only faults the server channel, the client proxy is still OK, because channel is not maintaining sessions in BasicHttpBinding, and when the client calls again and it is not expecting the channel to maintain any session.

- **WSHttpBinding** (have secure sessions): in case of an unhandled exception, it faults the server channel, the existing client proxy becomes useless since it is faulted. Further, with **wsHttpBinding** the channel is maintaining a secure session, when the client calls again it expects the channel to maintain the same session. The same session does not exist at the server channel anymore, as the undhandled exception has already torn down the channel and the session.


**why can't we simply throw .NET exceptions instead of Fault exceptions?**

A **WCF** service should throw only  a **FaultException** (or FaultException<T>) instead of **.Net Exceptions**:
1. An **unhandled .NET exception** will cause the **channel** between the client and the server to **fault**. Once the channel is in a faulted state we **cannot use** the **client proxy** anymore (i.e. we will have to re-create the proxy). Moreover, the **FaultExceptions** won't cause the communication channel to fault.

2. a **.NET exceptions** are platform specific, only understood by a .NET client, for interoperablity reason we should be throw **FaultExceptions**. [More...](18_Throwing_fault_exceptions_from_a_WCF_service)


**Create a strongly typed SOAP fault**:
1. Create a class that represents a SOAP fault. Decorate the class with DataContract attribute and the properties with DataMember attribute.
2. In the service data contract, use FaultContractAttribute to specify which operations can throw which SOAP faults.
3. In the service implementation create an instance of the strongly typed SOAP fault and throw it using FaultException<T>.
[More...](19_Creating_and_throwing_strongly_typed_SOAP_faults)


**Implementing IErrorHandler interface for Centralized exception handling**

[Code...](20_Centralized_exception_handling_in_WCF_by_implementing_IErrorHandler_interface)

1. Implement IErrorHandler interface, it has 2 methods we need to implementation:
	a. **ProvideFault** : Gets called sync (first) when there is an unhandled exception or a fault.used map unhandled exception into a generic fault to be returned to the client.
	
	b. **HandleError**: Gets called asynchronously after ProvideFault() method is called and the error message is returned to the client. Perfect place to log the exception without blocking the client call.
	

2. Create a **custom Service Behaviour Attribute** (e.g. GlobalErrorHandlerBehaviourAttribute) to let WCF know that we want to use the GlobalErrorHandler class whenever an unhandled exception occurs

Implements **IServiceBehavior** interface,which has 3 methods (Validate(), AddBindingParameters(), ApplyDispatchBehavior()). The implementation for Validate() and AddBindingParameters() method can be left blank. In the **ApplyDispatchBehavior()** method, we create an instance of the GlobalErrorHandler class and associate the instance with each channelDispatcher.

3. Decorate The Contract Service classwith **GlobalErrorHandlerBehaviourAttribute**
  


### Bindings in WCF	

The abc's of WCF Services :
1. Address: Where the WCF service is available. 
2. Binding: type of [binding](https://docs.microsoft.com/en-us/dotnet/framework/wcf/system-provided-bindings) (basicHttpBinding, wsHttpBinding, NetTcpBinding,...) 
3. Contract: The service contrat (interface) that exposes available operations to the client

**WCF binding**:

It defines how the client need to communicate with the service, the **binding** determines which **Transport Protocol**(http, tcp, namedpipe, msmq, ...), **Message encoding** (text/xml, binary...) and **Protocols**(reliable messaging, transport support,...) to be used.
for instance choosing **basicHttpBinding** binding would use **http** as Transport Protocol, **xml** as Message encoding and **no reliable** Protocol, whereas using **NetTcpBinding** binding would use **TCP** as as Transport Protocol, **binary** as Message encoding and we could customize **Protocols** to use.

[Choosing the right WCF binding](https://weblogs.asp.net/spano/choosing-the-right-wcf-binding)

 



###  IIS hosting Advantages and disadvantages
**Advantages**:
1. No code is required to host the service: The ServiceHost directive in .svc file is responsible for creating an instance of ServiceHost when required. There is no need to write code to instantiate and start ServiceHost, as is the case with self hosting.

2. Automatic message based activation: IIS provides automatic message based activation. This means that the service can be activated on demand. When a message arrives at the service, it then launches itself and fulfils the request. In case of self hosting, the service should always be running.

3. Automatic process recycling: IIS provides the capability of automatic process recycling, if the process is not healthy and if it's taking a long time to service the requests. We don't get automatic process recycling with self hosting.

**Disadvantages**:
Hosting WCF service in IIS 5.1 and IIS 6.0 is limited to HTTP communication only. This means we can only use HTTP related bindings.

To support Non-Http protocols in IIS (7 and above), we need to do the following:
1. Install WAS (Windows Process Activation Service) and "Windows foundation Non-Http Activation component" 
2. Enable Non-Http protocol support in IIS for your application.

**Enable net.tcp Protocol on IIS** : Open IIS->"DefaultWebSite" Folder,right click Manage application -advanced settings and set Enable Protocols = http, net.tcp.
		
###  WCF instancing modes 

There are 3 instancing modes: 
1. **PerCall**: A new instance of service object is created for every request, irrespective of whether the request comes from the same client or a different client.

2. **PerSession**: A new instance of the service object is created for each new client session and maintained for the duration of that session.

3. **Single**: A single instance of the service object is created and handles all requests for the lifetime of the application, irrespective of whether the request comes from the same client or a different client.

*How do we specify what instancing mode we want to use?* Use **ServiceBehavior** attribute and specify **InstanceContextMode**.

###  WCF bindings and the impact on message protection

What happens if the binding does not provide **security** and we have explicitly **set ProtectionLevel** other than None : An exception will be thrown. 

In general **ProtectionLevel** parameter is used to enforce the minimum level of **protection required**, If the **binding** does not provide that **minimum level of protection** then an exception will be thrown. 

###  Message Confidentiality and Integrity With Transport Security
 - Out of the box, **wsHttpBinding** provides **message** based **security**. Message based security automatically **encrypts and signs** the message to provide confidentiality and integrity.We have practically seen this by inspecting the logged messages. 
 
 - Out of the box, **netTcpBinding** provides **transport security**. Even with transport security, all messages are **encrypted and signed**. When we inspect the logged messages,	surprisingly they are in plain text. The reason for this is that, the messages are **encrypted and signed** at the **transport layer**. By the time the message is arrived at the log it is already **decrypted**. Therefore, they appear in **plain text**.


