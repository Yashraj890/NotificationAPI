using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdyNotificationService.Models
{
    public class ApiPropertiesCollection
#pragma warning restore SA1402 // File may only contain a single class
    {
#pragma warning disable S3052 // Members should not be initialized to default values
        public int SiteItemID = 0;
#pragma warning restore S3052 // Members should not be initialized to default values


        public ArrayList Items = new ArrayList();

        public ApiProperties this[string name]
        {
            get
            {
                lock (this.Items.SyncRoot)
                {
                    foreach (ApiProperties p in this.Items)
                    {
                        if (p.ApiID.ToLower() == name.ToLower())
                        {
                            return p;
                        }
                    }

                    return null;
                }
            }

            set
            {
                lock (this.Items.SyncRoot)
                {
                    if (value != null)
                    {// add or modify
                        ApiProperties p = this[value.ApiID];
                        if (p == null)
                        {
                            this.Items.Add(value);
                        }
                        else
                        {
#pragma warning disable S1854 // Dead stores should be removed
                            p = value;
#pragma warning restore S1854 // Dead stores should be removed
                        }
                    }
                    else
                    {// remove
                        ApiProperties objToRemove = null;
                        foreach (ApiProperties p in this.Items)
                        {
                            if (p.ApiID.ToLower() == value.ApiID.ToLower())
                            {
                                objToRemove = p;
#pragma warning disable S1227 // break statements should not be used except for switch cases
                                break;
#pragma warning restore S1227 // break statements should not be used except for switch cases
                            }
                        }

                        if (objToRemove != null)
                        {
                            this.Items.Remove(objToRemove);
                        }
                    }
                }
            }
        }



#pragma warning disable SA1201 // Elements must appear in the correct order
        public ApiPropertiesCollection()
        {
        }
#pragma warning restore SA1201 // Elements must appear in the correct order

        public ApiPropertiesCollection(int siid)
        {
            this.SiteItemID = siid;
        }

        [System.Xml.Serialization.XmlType("Odyssey.Repository.ApiPropertiesCollection.APIProperties")]
        public class ApiProperties
        {
            public string ApiID = string.Empty;

            public ArrayList Items = new ArrayList();

            public ApiProperty this[string name]
            {
                get
                {
                    lock (this.Items.SyncRoot)
                    {
                        foreach (ApiProperty p in this.Items)
                        {
                            if (p.Name.ToLower() == name.ToLower())
                            {
                                return p;
                            }
                        }

                        return null;
                    }
                }

                set
                {
                    lock (Items.SyncRoot)
                    {
                        if (value != null)
                        {// add or modify
                            ApiProperty p = this[value.Name];
                            if (p == null)
                            {
                                this.Items.Add(value);
                            }
                            else
                            {
#pragma warning disable S1854 // Dead stores should be removed
                                p = value;
#pragma warning restore S1854 // Dead stores should be removed
                            }
                        }
                        else
                        {// remove
                            ApiProperty objToRemove = null;
                            foreach (ApiProperty p in Items)
                            {
                                if (p.Name.ToLower() == value.Name.ToLower())
                                {
                                    objToRemove = p;
#pragma warning disable S1227 // break statements should not be used except for switch cases
                                    break;
#pragma warning restore S1227 // break statements should not be used except for switch cases
                                }
                            }

                            if (objToRemove != null)
                            {
                                this.Items.Remove(objToRemove);
                            }
                        }
                    }
                }
            }



#pragma warning disable SA1201 // Elements must appear in the correct order
            public ApiProperties()
            {
            }
#pragma warning restore SA1201 // Elements must appear in the correct order





            public ApiProperties(string apiID)
            {
                this.ApiID = apiID;
            }



            /// <inheritdoc/>
            public override string ToString()
            {
                return this.ApiID;
            }



#pragma warning disable SA1201 // Elements must appear in the correct order
            public static implicit operator string(ApiProperties p)
            {
                return p == null ? null : p.ApiID;
            }
#pragma warning restore SA1201 // Elements must appear in the correct order



            public class ApiProperty
            {
                public string Name = string.Empty;

                public string Value = string.Empty;

                public string DefaultValue = string.Empty;

                public bool ReadOnly = true;

                public ApiProperty()
                {
                }

                public ApiProperty(string name, string value, string defaultValue)
                {
                    this.Name = name;
                    this.Value = value;
                    this.DefaultValue = defaultValue;
                }


                /// <inheritdoc/>
                public override string ToString()
                {
                    return this.Name + ":" + this.Value;
                }



#pragma warning disable SA1201 // Elements must appear in the correct order
                public static implicit operator string(ApiProperty p)
                {
                    return p == null ? null : p.Value;
                }
#pragma warning restore SA1201 // Elements must appear in the correct order
            }
        }
    }
}
