﻿using System;
using System.IO;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;

namespace CS495_Capstone_Puma.OCR.S3Upload
{
    public class Upload
    {
        private static IAmazonS3 _client;

        public static void UploadDocument(string bucketName, string keyName, Stream inputStream, RegionEndpoint bucketRegion)
        {
            _client = new AmazonS3Client(bucketRegion);
            PutObjectResponse response = WritingAnObjectAsync(bucketName, keyName, inputStream);
        }

        private static PutObjectResponse WritingAnObjectAsync(string bucketName, string keyName, Stream inputStream)
        {
            try
            {
                var putRequest2 = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName,
                    InputStream = inputStream,
                    ContentType = "media/image"
                };
                putRequest2.Metadata.Add("x-amz-meta-title", "someTitle");
                return _client.PutObjectAsync(putRequest2).Result;
                
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine(
                        "Error encountered ***. Message:'{0}' when writing an object"
                        , e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(
                    "Unknown encountered on server. Message:'{0}' when writing an object"
                    , e.Message);
            }

            var getRequest = new GetObjectRequest
            {
                BucketName = bucketName,
                Key = keyName
            };

            var resp = _client.GetObjectAsync(getRequest).Result;
            

            return new PutObjectResponse();
        }
    }
}