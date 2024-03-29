﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace BcService
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "IService1" no arquivo de código e configuração ao mesmo tempo.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        //deve devolver true
        [WebInvoke(Method = "POST", UriTemplate = "/donator")]
        [Description("Posts a donator at xml file")]
        bool AddNewDonator(Donator bd);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/donator/DevolverXml")]
        string DevolverXml();

        //Método responsável por remover dadores
        [OperationContract]
        //deve vevolver true se eliminar
        [WebInvoke(Method = "DELETE", UriTemplate = "/donator/RemoveDonator/{id}")]
        [Description("Removes a donator/list of donators at xml file")]
        bool RemoverDonator(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/donator/ExportXml")]
        [Description("Gets a list of donators in xml file")]
        bool ExportarXML(List<int> posicao);

        


        // TODO: Adicione suas operações de serviço aqui
    }


    // Use um contrato de dados como ilustrado no exemplo abaixo para adicionar tipos compostos a operações de serviço.
    [DataContract]
    public class Donator
    {
        public Donator(int number, String sexo, String firstName, String lastName, String streetAddress,
                String city, String statefull, String zipCode, String eMail, String userName, String password,
                long telephoneNumber,
                String mothersMaiden, String birthDay, int age, String occupation, String company, String vehicle,
                String bloodType,
                double kilograms, double centimeters, String guid, String latitude, String longitude, double imc)
        {
            this.Number = number;
            this.Sexo = sexo;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.StreetAddress = streetAddress;
            this.City = city;
            this.Statefull = statefull;
            this.ZipCode = zipCode;
            this.EMail = eMail;
            this.UserName = userName;
            this.Password = password;
            this.TelephoneNumber = telephoneNumber;
            this.MothersMaiden = mothersMaiden;
            this.BirthDay = birthDay;
            this.Age = age;
            this.Occupation = occupation;
            this.Company = company;
            this.Vehicle = vehicle;
            this.BloodType = bloodType;
            this.Kilograms = kilograms;
            this.Centimeters = centimeters;
            this.Guid = guid;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Imc = imc;

        }
        [DataMember]
        public int Number { get; private set; }

        [DataMember]
        public String Sexo { get; private set; }

        [DataMember]
        public String FirstName { get; private set; }

        [DataMember]
        public String LastName { get; private set; }

        [DataMember]
        public String StreetAddress { get; private set; }

        [DataMember]
        public String City { get; private set; }

        [DataMember]
        public String Statefull { get; private set; }

        [DataMember]
        public String ZipCode { get; private set; }

        [DataMember]
        public String EMail { get; private set; }

        [DataMember]
        public String UserName { get; private set; }

        [DataMember]
        public String Password { get; private set; }

        [DataMember]
        public long TelephoneNumber { get; private set; }

        [DataMember]
        public String MothersMaiden { get; private set; }

        [DataMember]
        public String BirthDay { get; private set; }

        [DataMember]
        public int Age { get; private set; }

        [DataMember]
        public String Occupation { get; private set; }

        [DataMember]
        public String Company { get; private set; }

        [DataMember]
        public String Vehicle { get; private set; }

        [DataMember]
        public String BloodType { get; private set; }

        [DataMember]
        public double Kilograms { get; private set; }

        [DataMember]
        public double Centimeters { get; private set; }

        [DataMember]
        public String Guid { get; private set; }

        [DataMember]
        public String Latitude { get; private set; }

        [DataMember]
        public String Longitude { get; private set; }

        [DataMember]
        public double Imc { get; private set; }

        public override string ToString()
        {
            string bd = string.Empty;
            bd += "Number: " + Number + Environment.NewLine;
            bd += "Sex: " + Sexo + Environment.NewLine;
            bd += "First Name: " + FirstName + Environment.NewLine;
            bd += "Last Name: " + LastName + Environment.NewLine;
            bd += "Street Address: " + StreetAddress + Environment.NewLine;
            bd += "City: " + City + Environment.NewLine;
            bd += "Statefull: " + Statefull + Environment.NewLine;
            bd += "ZipCode: " + ZipCode + Environment.NewLine;
            bd += "EMail: " + EMail + Environment.NewLine;
            bd += "UserName: " + UserName + Environment.NewLine;
            bd += "Password: " + Password + Environment.NewLine;
            bd += "TelephoneNumber: " + TelephoneNumber + Environment.NewLine;
            bd += "MothersMaiden: " + MothersMaiden + Environment.NewLine;
            bd += "BirthDay: " + BirthDay + Environment.NewLine;
            bd += "Age: " + Age + Environment.NewLine;
            bd += "Occupation: " + Occupation + Environment.NewLine;
            bd += "Company: " + Company + Environment.NewLine;
            bd += "Vehicle: " + Vehicle + Environment.NewLine;
            bd += "BloodType: " + BloodType + Environment.NewLine;
            bd += "Kilograms: " + Kilograms + Environment.NewLine;
            bd += "Centimeters: " + Centimeters + Environment.NewLine;
            bd += "Guid: " + Guid + Environment.NewLine;
            bd += "Latitude: " + Latitude + Environment.NewLine;
            bd += "Longitude: " + Longitude + Environment.NewLine;
            bd += "Imc: " + Imc + Environment.NewLine;

            return bd;
        }
    }
        
    
}
