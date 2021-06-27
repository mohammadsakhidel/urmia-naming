using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Models;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IInputPasswaysService" in both code and config file together.
[ServiceContract]
public interface IInputPasswaysService
{
	[OperationContract]
	Tuple<bool, string> AddPasswayRecord(Passway serverRecord);

    [OperationContract]
    Tuple<bool, string> UpdatePasswayRecord(Passway serverEditedRecord);
}
