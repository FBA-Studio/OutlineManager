using System;

namespace OutlineManager.Types
{
	/// <summary>
	/// Info about Outline Key
	/// </summary>
	public class OutlineKey
	{
        /// <value>Key ID</value>
        public int Id;
		/// <value>Name of key</value>
		public string Name;
		/// <value>Password of key</value>
		public string Password;
		/// <value>Port of key</value>
		public int Port;
		/// <value>Method for password of key</value>
		public string Method;
		/// <value><see cref="T:OutlineManager.Types.DataLimit"/> of key</value>
        public DataLimit DataLimit;
        /// <value>Access URL for using in Outline Client App</value>
        public string AccessUrl;
	}

}

