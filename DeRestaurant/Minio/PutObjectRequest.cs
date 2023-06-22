using System;
namespace DeRestaurant.Minio
{
	public class PutObjectRequest
	{
        public string bucket { get; set; }
        public byte[] data { get; set; }
    }
}

