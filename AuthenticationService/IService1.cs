using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AuthenticationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string Login(string username, string password, string userXmlPath);
        [OperationContract]
        string Register(string username, string password, string userXmlPath);
       
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class User
    {
        private string username;
        private string hashedPassword;

        [DataMember]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        [DataMember]
        public string HashedPassword
        {
            get { return hashedPassword; }
            set { hashedPassword = value; }
        }
    }
    [CollectionDataContract(Name = "Users", ItemName = "User")]
    public class UserList : List<User>
    {
        
    }
}
