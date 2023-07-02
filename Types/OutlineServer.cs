using System;

namespace OutlineManager.Types {
    public class OutlineServer {
        ///<svalue>Name of Outline Server</value>
        public string Name;
        
        ///<value>ID of Outline Server</value>
        public string ServerId;
        
        ///<value><b>True</b>, if metrics enabled on this server</value>
        public bool MetricsEnabled;
        
        ///<value>Version of Outline Server</value>
        public string Version;
        
        ///<value>Port for new access keys</value>
        public int PortForNewAccessKeys;
        
        ///<value>IP/Hostname server for access keys</value>
        public string HostnameForAccessKeys;
    }
}
