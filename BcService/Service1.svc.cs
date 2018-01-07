
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Hosting;
using System.Xml;
using System.Xml.Linq;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace BcService
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "Service1" no arquivo de código, svc e configuração ao mesmo tempo.
    // OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione Service1.svc ou Service1.svc.cs no Gerenciador de Soluções e inicie a depuração.
    public class Service1 : IService1
    {
        private static string FILEPATH;
        public Service1()
        {
            FILEPATH = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "BaseDados.xml");
        }
        public string DevolverXml()
        {

            XDocument doc = XDocument.Load(FILEPATH);
            return doc.ToString();

        }


        public bool RemoverDonator(string id)
        {
            bool sucesso = true;
            try
            {

                XmlDocument doc = new XmlDocument();
                doc.Load(FILEPATH);
                XmlNode node = doc.SelectSingleNode("//Donator[@id=" + id + "]");
                XmlNode root = doc.DocumentElement;
                root.RemoveChild(node);
                doc.Save(FILEPATH);
            }
            catch (Exception e)
            {
                sucesso = false;
            }
            return sucesso;
        }

        public bool AddNewDonator(Donator bd)
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(FILEPATH);
            XmlNode root = doc.DocumentElement;
            XmlNode id = root.SelectSingleNode("Donator[last()]/@id");
            int idU = Convert.ToInt32(id.InnerText);
            String idUltimo = Convert.ToString(idU + 1);

            XmlElement donator = doc.CreateElement("Donator");
            donator.SetAttribute("id", idUltimo);
            //doc.AppendChild(donator);

            XmlElement genero = doc.CreateElement("Sexo");
            donator.AppendChild(genero);
            genero.InnerText = bd.Sexo;

            XmlElement primeiroNome = doc.CreateElement("Primeiro_Nome");
            donator.AppendChild(primeiroNome);
            primeiroNome.InnerText = bd.FirstName;

            XmlElement ultimoNome = doc.CreateElement("Ultimo_Nome");
            donator.AppendChild(ultimoNome);
            ultimoNome.InnerText = bd.LastName;

            XmlElement rua = doc.CreateElement("Rua");
            donator.AppendChild(rua);
            rua.InnerText = bd.StreetAddress;

            XmlElement cidade = doc.CreateElement("Cidade");
            donator.AppendChild(cidade);
            cidade.InnerText = bd.City;

            XmlElement distrito = doc.CreateElement("Distrito");
            donator.AppendChild(distrito);
            distrito.InnerText = bd.Statefull;

            XmlElement codigoPostal = doc.CreateElement("Codigo_Postal");
            donator.AppendChild(codigoPostal);
            codigoPostal.InnerText = bd.ZipCode;

            XmlElement mail = doc.CreateElement("Email");
            donator.AppendChild(mail);
            mail.InnerText = bd.EMail;

            XmlElement userN = doc.CreateElement("Username");
            donator.AppendChild(userN);
            userN.InnerText = bd.UserName;

            XmlElement pwd = doc.CreateElement("Password");
            donator.AppendChild(pwd);
            pwd.InnerText = bd.Password;

            XmlElement telefone = doc.CreateElement("Telefone");
            donator.AppendChild(telefone);
            telefone.InnerText = Convert.ToString(bd.TelephoneNumber);

            XmlElement nomeDaMae = doc.CreateElement("Nome_da_mae");
            donator.AppendChild(nomeDaMae);
            nomeDaMae.InnerText = bd.MothersMaiden;

            XmlElement dataNasc = doc.CreateElement("Data_Nascimento");
            donator.AppendChild(dataNasc);
            dataNasc.InnerText = bd.BirthDay;

            XmlElement idade = doc.CreateElement("Idade");
            donator.AppendChild(idade);
            idade.InnerText = Convert.ToString(bd.Age);

            XmlElement ocupacao = doc.CreateElement("Ocupaçao");
            donator.AppendChild(ocupacao);
            ocupacao.InnerText = bd.Occupation;

            XmlElement empresa = doc.CreateElement("Empresa");
            donator.AppendChild(empresa);
            empresa.InnerText = bd.Company;

            XmlElement veiculo = doc.CreateElement("Veiculo");
            donator.AppendChild(veiculo);
            veiculo.InnerText = bd.Vehicle;

            XmlElement tipoSanguineo = doc.CreateElement("Tipo_Sanguineo");
            donator.AppendChild(tipoSanguineo);
            tipoSanguineo.InnerText = bd.BloodType;

            XmlElement peso = doc.CreateElement("Peso");
            donator.AppendChild(peso);
            peso.InnerText = Convert.ToString(bd.Kilograms);

            XmlElement altura = doc.CreateElement("Altura");
            donator.AppendChild(altura);
            altura.InnerText = Convert.ToString(bd.Centimeters);

            XmlElement guId = doc.CreateElement("GUID");
            donator.AppendChild(guId);
            guId.InnerText = bd.Guid;

            XmlElement lat = doc.CreateElement("Latitude");
            donator.AppendChild(lat);
            lat.InnerText = bd.Latitude;

            XmlElement lon = doc.CreateElement("Longitude");
            donator.AppendChild(lon);
            lon.InnerText = bd.Longitude;
            
            root.AppendChild(donator);
            doc.Save(FILEPATH);


            return true;
        }
        public bool ExportarXML(List<int> posicao)
        {
            XmlDocument docExportar = new XmlDocument();
            XmlDeclaration decExportar = docExportar.CreateXmlDeclaration("1.0", null, null);
            docExportar.AppendChild(decExportar);
            XmlElement rootExportar = docExportar.CreateElement("DonatorsList"); // Criar um root onde os Elementos Donators irão ser introduzidos
            docExportar.AppendChild(rootExportar);

            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            
            for(int i = 0;i<posicao.Count();i++)
            {
               
                XmlNode dador = doc.SelectSingleNode("Donator[id = " + posicao[i].ToString()+ "]");
                rootExportar.AppendChild(dador);
            }
            
            docExportar.Save(caminho);
            return true;
        }
    


    }
}
