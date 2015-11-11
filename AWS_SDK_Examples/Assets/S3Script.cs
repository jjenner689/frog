using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Runtime;
using System.IO;
using System;
using Amazon.S3.Util;
using System.Collections.Generic;
using Amazon.CognitoIdentity;
using Amazon;

public class S3Script : MonoBehaviour {
    public string IdentityPoolId = "";

    public string S3BucketName = null;
    public string SampleFileName = null;
    public string Region = "EUWest1";
    public Button GetBucketListButton = null;
    public Button PostBucketButton = null;
    public Button GetObjectsListButton = null;
    public Button DeleteObjectButton = null;
    public Button GetObjectButton = null;
    public Text ResultText = null;
    AmazonS3Config S3Config = new AmazonS3Config()
    {
        ServiceURL = "s3.amazonaws.com",
        RegionEndpoint = Amazon.RegionEndpoint.EUWest1
    };
    private AWSCredentials _credentials=null;
    private AWSCredentials Credentials
    {
        get
        {
            if (_credentials == null)
                _credentials = new CognitoAWSCredentials(IdentityPoolId, RegionEndpoint.USEast1);
            return _credentials;
        }
    }
    private AmazonS3Client S3Client;

    // Use this for initialization
    void Start () {
        // ResultText is a label used for displaying status information
        Debug.Log("hallo1");

        


    Debug.Log("hallo2");
        S3Client = new AmazonS3Client(Credentials);
        Debug.Log("hallo3");
        ResultText.text = "Fetching all the Buckets";
        S3Client.ListBucketsAsync(new ListBucketsRequest(), (responseObject) =>
        {
            ResultText.text += "\n";
            if (responseObject.Exception == null)
            {
                ResultText.text += "Got Response \nPrinting now \n";
                responseObject.Response.Buckets.ForEach((s3b) =>
                {
                    ResultText.text += string.Format("bucket = {0}, created date = {1} \n",
                    s3b.BucketName, s3b.CreationDate);
                });
            }
            else
            {
                ResultText.text += "Got Exception \n";
            }
        });
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
