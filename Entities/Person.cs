using System;

namespace AsyncAspNetRequestTxInterceptor.Entities
{
    [Serializable]
    public abstract class Person
    {
		private long _iD;
		
        private string _rtn;

        private string _phoneNo;

        private string _email;

        private string _webPage;

        private string __name;

		public virtual long ID
        {
			set
            {
				_iD = value;
			}
			
			get
            {
				return _iD;
			}
		}

        public virtual string WebPage
        {
            set
            {
                _webPage = value;
            }

            get
            {
                return _webPage;
            }
        }

        public virtual string Rtn
        {
            set
            {
                _rtn = value;
            }

            get
            {
                return _rtn;
            }
        }

        public virtual string PhoneNo
        {
            set
            {
                _phoneNo = value;
            }

            get
            {
                return _phoneNo;
            }
        }

        public virtual string Email
        {
            set
            {
                _email = value;
            }

            get
            {
                return _email;
            }
        }

        public virtual string Name
        {
            get
            {
                return __name;
            }
            set
            {
                __name = value;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
