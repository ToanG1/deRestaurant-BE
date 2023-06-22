using System;
using Minio;

namespace DeRestaurant.Minio
{
	public class MinioObject
	{
        private MinioClient _minio;
        public MinioObject()
		{
            _minio = new MinioClient()
			.WithEndpoint("localhost:9000")
			.WithCredentials("61qc7Hc6g3a2rgjc",
            "g4Lmq9aDokEFzGYg4w9l5n6FIG2aiH6r")
			.Build();
        }
        public async Task<string> PutObj(PutObjectRequest request)
        {
            var bucketName = request.bucket;
            // Check Exists bucket
            bool found = await _minio.BucketExistsAsync(new BucketExistsArgs().WithBucket(bucketName));
            if (!found)
            {
                // if bucket not Exists,make bucket
                await _minio.MakeBucketAsync(new MakeBucketArgs().WithBucket(bucketName));
            }
            System.IO.MemoryStream filestream = new System.IO.MemoryStream(request.data);
            var filename = Guid.NewGuid();
            // upload object
            await _minio.PutObjectAsync(new PutObjectArgs()
            .WithBucket(bucketName)
            .WithObject("review/" + filename.ToString())
            .WithContentType("image/jpeg")
            .WithStreamData(filestream).WithObjectSize(filestream.Length)
            );
            return await Task.FromResult<string>(filename.ToString());
        }

        public async Task<GetObjectReply> GetObject(string bucket, string objectname)
        {
            MemoryStream destination = new MemoryStream();
            // Check Exists object
            var objstatreply = await _minio.StatObjectAsync(new StatObjectArgs()
            .WithBucket(bucket)
            .WithObject("review/"+objectname)
            );
            if (objstatreply == null || objstatreply.DeleteMarker)
                throw new Exception("object not found or Delete");
            // Get object
            await _minio.GetObjectAsync(new GetObjectArgs()
            .WithBucket(bucket)
            .WithObject("review/"+objectname)
            .WithCallbackStream((stream) =>
            {
                stream.CopyTo(destination);
            }
            )
            );
            return await Task.FromResult<GetObjectReply>(new GetObjectReply()
            {
                data = destination.ToArray(),
                objectstat = objstatreply
            });
        }
    }
}

