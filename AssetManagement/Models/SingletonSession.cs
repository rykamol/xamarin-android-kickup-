using System;

namespace AssetManagement.Models
{
    public class SingletonSession
    {

        private static SingletonSession instance;
        private String username;
        private string plantid;
        //no outer class can initialize this class's object
        private SingletonSession() { }

        public static SingletonSession Instance()
        {
            //if no instance is initialized yet then create new instance
            //else return stored instance
            if (instance == null)
            {
                instance = new SingletonSession();
            }
            return instance;
        }

        public String getUsername()
        {
            return username;
        }

        public void setUsername(String username)
        {
            this.username = username;
        }
        public String getPlantID()
        {
            return plantid;
        }

        public void setPlantID(String PlantID)
        {
            this.plantid = PlantID;
        }

    }
}