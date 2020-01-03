using System;
using System.Text;

namespace AsyncAspNetRequestTxInterceptor.Entities {
	[Serializable]
	public class NaturalPerson: Person {

		private string _personalIdentity;
		
		private string _name1;
		
		private string _name2;
		
		private string _lastName1;
		
		private string _lastName2;
		
		private string _mobileNo;
		
	    private string _document;

        [NonSerialized]
        private string _name;
		
		public virtual string PersonalIdentity {
			set {
				_personalIdentity = value;
			}
			
			get {
				return _personalIdentity;
			}
		}

        public virtual string Document
        {
            set
            {
                _document = value;
            }

            get
            {
                return _document;
            }
        }
				
		public virtual string Name1 {
			set {
				_name1 = value;
			}
			
			get {
				return _name1;
			}
		}
		
		public virtual string Name2 {
			set {
				_name2 = value;
			}
			
			get {
				return _name2;
			}
		}
		
		public virtual string LastName1 {
			set {
				_lastName1 = value;
			}
			
			get {
				return _lastName1;
			}
		}
		
		public virtual string LastName2 {
			set {
				_lastName2 = value;
			}
			
			get {
				return _lastName2;
			}
		}
		
		public virtual string MobileNo {
			set {
				_mobileNo = value;
			}
			
			get {
				return _mobileNo;
			}
		}
		
        public override string Name
        {
            get
            {
                if (_name == null)
                {
                    var sb = new StringBuilder();
                    if (LastName1 != null) sb.Append(LastName1.Trim());
                    if (LastName2 != null)
                    {
                        if (sb.Length > 0) sb.Append(' ');
                        sb.Append(LastName2.Trim());
                    }

                    if (sb.Length > 0) sb.Append(", ");

                    if (Name1 != null) sb.Append(Name1.Trim());
                    if (Name2 != null)
                    {
                        if (sb.Length > 0) sb.Append(' ');
                        sb.Append(Name2.Trim());
                    }

                    _name = sb.ToString();
                }
                return _name;
            }
            set { _name = value; }
        }
        
        public override string ToString() {
			return base.ToString();
		}
		
	}
}
