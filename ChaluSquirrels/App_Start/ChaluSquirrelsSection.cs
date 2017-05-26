using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ChaluSquirrels
{
    public class ChaluSquirrelsSection : ConfigurationSection
    {

        [ConfigurationProperty("header")]
        public Header Header
        {
            get { return (Header)this["header"]; }
            set { this["header"] = value; }
        }

        [ConfigurationProperty("menus")]        
        public Menu Menus
        {
            get { return (Menu)this["menus"]; }
            set { this["menus"] = value; }
        }


        [ConfigurationProperty("portfolios")]
        public Portfolios Portfolios
        {
            get { return (Portfolios)this["portfolios"]; }
            set { this["portfolios"] = value; }
        }
    }




    public class Header : ConfigurationElement
    {
        [ConfigurationProperty("bigImage")]
        public string BigImage
        {
            get { return (string)this["bigImage"]; }
            set { this["bigImage"] = value; }
        }

        [ConfigurationProperty("bigImageCenterKeywords")]
        public string BigImageCenterKeywords
        {
            get { return (string)this["bigImageCenterKeywords"]; }
            set { this["bigImageCenterKeywords"] = value; }
        }

        [ConfigurationProperty("bigImageCenterDescription")]
        public string BigImageCenterDescription
        {
            get { return (string)this["bigImageCenterDescription"]; }
            set { this["bigImageCenterDescription"] = value; }
        }

        [ConfigurationProperty("bigImageCenterButtons")]
        public Buttons BigImageCenterButtons
        {
            get { return (Buttons)this["bigImageCenterButtons"]; }
            set { this["bigImageCenterButtons"] = value; }
        }
    }


    [ConfigurationCollection(typeof(Button), AddItemName = "add", ClearItemsName = "clear")]    
    public class Buttons : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new Button();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Button)element).Id;
        }

        public void Add(Button table)
        {
            BaseAdd(table);
        }
        public void Clear()
        {
            BaseClear();
        }

        public List<Button> GetList()
        {
            return BaseGetAllKeys().Select(key => (Button)BaseGet(key)).ToList();
        }
        new public Button this[string serviceName]
        {
            get
            {
                return (Button)BaseGet(serviceName);
            }
        }
    }

    public class Button : ConfigurationElement
    {
        [ConfigurationProperty("id", IsKey = true, IsRequired = true)]
        public string Id
        {
            get { return (string)this["id"]; }
            set { this["id"] = value; }
        }

        [ConfigurationProperty("text", IsRequired=true)]
        public string Text
        {
            get { return (string)this["text"]; }
            set { this["text"] = value; }
        }

        [ConfigurationProperty("link",DefaultValue="#")]
        public string Link
        {
            get { return (string)this["link"]; }
            set { this["link"] = value; }
        }
    }


    [ConfigurationCollection(typeof(Portfolio), AddItemName="portfolio")]
    public class Portfolios : ConfigurationElementCollection
    {        
        protected override ConfigurationElement CreateNewElement()
        {
            return new Portfolio();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Portfolio)element).Id;
        }

        //public void Add(Image table)
        //{
        //    BaseAdd(table);
        //}
        //public void Clear()
        //{
        //    BaseClear();
        //}

        //public List<Image> GetList()
        //{
        //    return BaseGetAllKeys().Select(key => (Image)BaseGet(key)).ToList();
        //}

        new public Portfolio this[string id]
        {
            get
            {
                return (Portfolio)BaseGet(id);
            }
        }
    }




    [ConfigurationCollection(typeof(Image), AddItemName = "add", ClearItemsName = "clear")]
    public class Portfolio : ConfigurationElementCollection
    {
        [ConfigurationProperty("id", IsRequired = true)]
        public string Id
        {
            get { return (string)this["id"]; }
            set { this["id"] = value; }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new Image();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return Guid.NewGuid();
        }

        public void Add(Image table)
        {
            BaseAdd(table);
        }
        public void Clear()
        {
            BaseClear();
        }

        public List<Image> GetList()
        {
            return BaseGetAllKeys().Select(key => (Image)BaseGet(key)).ToList();
        }
        //new public Image this[string serviceName]
        //{
        //    get
        //    {
        //        return (Image)BaseGet(serviceName);
        //    }
        //}
    }

    public class Image : ConfigurationElement
    {
        [ConfigurationProperty("title")]
        public string Title
        {
            get { return (string)this["title"]; }
            set { this["title"] = value; }
        }

        [ConfigurationProperty("path")]
        public string Path
        {
            get { return (string)this["path"]; }
            set { this["path"] = value; }
        }
    }





    [ConfigurationCollection(typeof(MenuItem), AddItemName = "add", ClearItemsName = "clear")]    
    public class Menu : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new MenuItem();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MenuItem)element).Id;
        }

        public void Add(MenuItem table)
        {
            BaseAdd(table);
        }
        public void Clear()
        {
            BaseClear();
        }

        public List<MenuItem> GetList()
        {
            return BaseGetAllKeys().Select(key => (MenuItem)BaseGet(key)).ToList();
        }
        new public MenuItem this[string serviceName]
        {
            get
            {
                return (MenuItem)BaseGet(serviceName);
            }
        }

    }

    public class MenuItem : ConfigurationElement
    {
        [ConfigurationProperty("id", IsKey=true, IsRequired=true)]
        public string Id
        {
            get { return (string)this["id"]; }
            set { this["id"] = value; }
        }

        [ConfigurationProperty("name")]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("portfolioId")]
        public string PortfolioId
        {
            get { return (string)this["portfolioId"]; }
            set { this["portfolioId"] = value; }
        }

        [ConfigurationProperty("description")]
        public CustomElement<string> Description
        {
            get { return (CustomElement<string>)this["description"]; }
            set { this["description"] = value; }
        }
    }
    
    public class CustomElement<T> : ConfigurationElement
    {
        [ConfigurationProperty("value")]
        public T Value
        {
            get { return (T)this["value"]; }
            set { this["value"] = value; }
        }
    }
}