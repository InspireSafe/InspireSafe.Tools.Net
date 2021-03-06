#region Copyright and License
// Copyright 2010..11 Alexander Reinert
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

namespace InspireSafe.Tools.Net.Dns.DnsRecord
{
	public class DhcpIRecord : DnsRecordBase
	{
		public byte[] RecordData { get; private set; }

		internal DhcpIRecord() {}

		public DhcpIRecord(DomainName name, int timeToLive, byte[] recordData)
			: base(name, RecordType.Dhcid, RecordClass.INet, timeToLive)
		{
			RecordData = recordData ?? new byte[] { };
		}

		internal override void ParseRecordData(byte[] resultData, int startPosition, int length)
		{
			RecordData = DnsMessageBase.ParseByteData(resultData, ref startPosition, length);
		}

		internal override void ParseRecordData(DomainName origin, string[] stringRepresentation)
		{
			throw new NotImplementedException();
		}

		internal override string RecordDataToString()
		{
			return RecordData.ToBase64String();
		}

		protected internal override int MaximumRecordDataLength
		{
			get { return RecordData.Length; }
		}

		protected internal override void EncodeRecordData(byte[] messageData, int offset, ref int currentPosition, Dictionary<DomainName, ushort> domainNames,
			bool useCanonical)
		{
			DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, RecordData);
		}
	}
}