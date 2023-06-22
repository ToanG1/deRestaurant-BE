using System;
using Minio.DataModel;
namespace DeRestaurant.Minio
{
	public class GetObjectReply
	{
        public ObjectStat objectstat { get; set; }
        public byte[] data { get; set; }
    }
}

