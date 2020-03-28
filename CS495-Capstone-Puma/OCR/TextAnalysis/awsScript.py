import boto3
import time
import sys
import json

def startJob(s3BucketName, objectName):
    client = boto3.client('textract')
    response = client.start_document_analysis(
        DocumentLocation={
            'S3Object': {
                'Bucket': s3BucketName,
                'Name': objectName
            }
        },
        FeatureTypes=['TABLES', 'FORMS'])

    return response["JobId"]

def isJobComplete(jobId):
    time.sleep(5)
    client = boto3.client('textract')
    response = client.get_document_analysis(JobId=jobId)
    status = response["JobStatus"]

    while(status == "IN_PROGRESS"):
        time.sleep(5)
        response = client.get_document_analysis(JobId=jobId)
        status = response["JobStatus"]

    return status

def getJobResults(jobId):

    pages = []

    time.sleep(5)

    client = boto3.client('textract')
    response = client.get_document_analysis(JobId=jobId)

    pages.append(response)
    nextToken = None
    if 'NextToken' in response:
        nextToken = response['NextToken']

    while nextToken:
        time.sleep(5)

        response = client.get_document_analysis(JobId=jobId, NextToken=nextToken)

        pages.append(response)
        nextToken = None
        if 'NextToken' in response:
            nextToken = response['NextToken']

    return pages


# Document
s3BucketName = "pdfidentify"
documentName = sys.argv[1]

jobId = startJob(s3BucketName, documentName)
jobStatus = isJobComplete(jobId)
response = getJobResults(jobId)

print(json.dumps(response))
