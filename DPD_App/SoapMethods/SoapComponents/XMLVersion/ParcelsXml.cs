using System.Xml.Serialization;
using DPD_App.Models;

namespace DPD_App.SoapMethods.SoapComponents;

[XmlRoot(ElementName="Parcels", Namespace="")]
public class ParcelsXml
{
    [XmlElement(ElementName = "Parcel")] public List<ParcelXml>? Parcel { get; set; } = [new ParcelXml()];
}