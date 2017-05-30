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

        [ConfigurationProperty("contact")]
        public Contact Contact
        {
            get { return (Contact)this["contact"]; }
            set { this["contact"] = value; }
        }

        [ConfigurationProperty("team")]
        public Team Team
        {
            get { return (Team)this["team"]; }
            set { this["team"] = value; }
        }
    }




    #region Header image, text and buttons
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

        [ConfigurationProperty("text", IsRequired = true)]
        public string Text
        {
            get { return (string)this["text"]; }
            set { this["text"] = value; }
        }

        [ConfigurationProperty("link", DefaultValue = "#")]
        public string Link
        {
            get { return (string)this["link"]; }
            set { this["link"] = value; }
        }
    }
    
    #endregion


    #region Portfolio
    [ConfigurationCollection(typeof(Portfolio), AddItemName = "portfolio")]
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
    
    #endregion


    #region Menu items

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
        [ConfigurationProperty("id", IsKey = true, IsRequired = true)]
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

        [ConfigurationProperty("showContactDetails", DefaultValue = false)]
        public bool ShowContactDetails
        {
            get { return (bool)this["showContactDetails"]; }
            set { this["showContactDetails"] = value; }
        }

        [ConfigurationProperty("showTeamMembers", DefaultValue = false)]
        public bool ShowTeamMembers
        {
            get { return (bool)this["showTeamMembers"]; }
            set { this["showTeamMembers"] = value; }
        }
    } 
    #endregion


    #region Contact
    public class Contact : ConfigurationElement
    {
        
        [ConfigurationProperty("address")]
        public Address Address
        {
            get { return (Address)this["address"]; }
            set { this["address"] = value; }
        }

        [ConfigurationProperty("customerSupport")]
        public CustomerSupport CustomerSupport
        {
            get { return (CustomerSupport)this["customerSupport"]; }
            set { this["customerSupport"] = value; }
        }

        [ConfigurationProperty("socialLinks")]
        public SocialLinks SocialLinks
        {
            get { return (SocialLinks)this["socialLinks"]; }
            set { this["socialLinks"] = value; }
        }        
    }

    public class CustomerSupport : ConfigurationElement
    {
        [ConfigurationProperty("visible", DefaultValue = true)]
        public bool Visible
        {
            get { return (bool)this["visible"]; }
            set { this["visible"] = value; }
        }

        [ConfigurationProperty("heading", DefaultValue = "Customer Support")]
        public string Heading
        {
            get { return (string)this["heading"]; }
            set { this["heading"] = value; }
        }

        [ConfigurationProperty("email")]
        public string Email
        {
            get { return (string)this["email"]; }
            set { this["email"] = value; }
        }

        [ConfigurationProperty("phone")]
        public string Phone
        {
            get { return (string)this["phone"]; }
            set { this["phone"] = value; }
        }
    }


    [ConfigurationCollection(typeof(SocialLink), AddItemName = "add", ClearItemsName = "clear")]
    public class SocialLinks : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new SocialLink();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return Guid.NewGuid() ;
        }

        public void Add(SocialLink table)
        {
            BaseAdd(table);
        }
        public void Clear()
        {
            BaseClear();
        }

        public List<SocialLink> GetList()
        {
            return BaseGetAllKeys().Select(key => (SocialLink)BaseGet(key)).ToList();
        }
        new public SocialLink this[string serviceName]
        {
            get
            {
                return (SocialLink)BaseGet(serviceName);
            }
        }

    }

    public class SocialLink : ConfigurationElement
    {
        [ConfigurationProperty("visible", DefaultValue = true)]
        public bool Visible
        {
            get { return (bool)this["visible"]; }
            set { this["visible"] = value; }
        }

        [ConfigurationProperty("title")]
        public string Title
        {
            get { return (string)this["title"]; }
            set { this["title"] = value; }
        }

        [ConfigurationProperty("logoName")]
        public string LogoName
        {
            get { return (string)this["logoName"]; }
            set { this["logoName"] = value; }
        }

        [ConfigurationProperty("link")]
        public string Link
        {
            get { return (string)this["link"]; }
            set { this["link"] = value; }
        }
    }

    public class Address : ConfigurationElement
    {
        [ConfigurationProperty("visible", DefaultValue = true)]
        public bool Visible
        {
            get { return (bool)this["visible"]; }
            set { this["visible"] = value; }
        }

        [ConfigurationProperty("heading", DefaultValue = "Address")]
        public string Heading
        {
            get { return (string)this["heading"]; }
            set { this["heading"] = value; }
        }

        [ConfigurationProperty("lineOne", IsRequired = true)]
        public string LineOne
        {
            get { return (string)this["lineOne"]; }
            set { this["lineOne"] = value; }
        }

        [ConfigurationProperty("lineTwo")]
        public string LineTwo
        {
            get { return (string)this["lineTwo"]; }
            set { this["lineTwo"] = value; }
        }

        [ConfigurationProperty("lineThree")]
        public string LineThree
        {
            get { return (string)this["lineThree"]; }
            set { this["lineThree"] = value; }
        }
    } 
    #endregion


    #region Team members
    [ConfigurationCollection(typeof(TeamMember), AddItemName = "add", ClearItemsName = "clear")]
    public class Team : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new TeamMember();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return Guid.NewGuid();
        }

        public void Add(TeamMember table)
        {
            BaseAdd(table);
        }
        public void Clear()
        {
            BaseClear();
        }

        public List<TeamMember> GetList()
        {
            return BaseGetAllKeys().Select(key => (TeamMember)BaseGet(key)).ToList();
        }
        new public TeamMember this[string serviceName]
        {
            get
            {
                return (TeamMember)BaseGet(serviceName);
            }
        }
    }

    public class TeamMember : ConfigurationElement
    {
        [ConfigurationProperty("profilePic", DefaultValue = "/Image/defaultUser.png")]
        public string ProfilePic
        {
            get { return (string)this["profilePic"]; }
            set { this["profilePic"] = value; }
        }

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("designation")]
        public string Designation
        {
            get { return (string)this["designation"]; }
            set { this["designation"] = value; }
        }

        [ConfigurationProperty("oneLine")]
        public string OneLine
        {
            get { return (string)this["oneLine"]; }
            set { this["oneLine"] = value; }
        }

        [ConfigurationProperty("socialLinks")]
        public SocialLinks SocialLinks
        {
            get { return (SocialLinks)this["socialLinks"]; }
            set { this["socialLinks"] = value; }
        }
    } 
    #endregion

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