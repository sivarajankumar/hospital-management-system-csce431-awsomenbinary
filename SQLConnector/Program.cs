using System;

namespace SQLConnector{

    class Program{

        static void Main(string[] args){
            SQLConnector c = new SQLConnector("192.168.1.102", "djnemec-hosp", "djnemec", "csce431");
            c.connect();

            if (c.userExists("dan") && c.verifyUser("dan", "pass")){
                Console.WriteLine("User exists!");
            }
            
            if(!c.userExists("test1")){
                c.addUser("test1", "ppp");
                Console.WriteLine("Error adding user");
            }
            if (!c.userExists("test1")) {
                Console.WriteLine("Error adding user");
            }
            c.disconnect();

        }
    }
}
