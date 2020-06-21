# WCF - Legacy

## KEYNOTES 

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

1. Right click on the config file and select "Edit WCF Configuration" option from the context menu. If you don't see this option, click on Tools menu item and then selecct WCF Configuration Editor and then point to the config file. 
2. Select Diagnostics folder
3. Click on Enable Log Auto Flush link.
4. Then click on Enable Message Logging link. This should automatically add file, to which messages will be logged. To enable tracing click on Enable Tracing link.
5. Expand Diagnostics folder on the left hand side
6. Select Message Logging item that is present under Diagnostics folder. On the right hand side set LogEntireMessage option to true.
7. Close Microsoft Service Configuration Editor tool. This will ask you to Save Changes. Click Yes.


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

**MessageHeader** attribute is applied on a property of the class that you want to include in the **SOAP header**. 
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









