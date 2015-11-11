//
// Copyright 2014-2015 Amazon.com, 
// Inc. or its affiliates. All Rights Reserved.
// 
// Licensed under the Amazon Software License (the "License"). 
// You may not use this file except in compliance with the 
// License. A copy of the License is located at
// 
//     http://aws.amazon.com/asl/
// 
// or in the "license" file accompanying this file. This file is 
// distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, express or implied. See the License 
// for the specific language governing permissions and 
// limitations under the License.
//
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;

#pragma warning disable 1591

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// Delete Bucket Lifecycle Request Marshaller
    /// </summary>       
    public class DeleteLifecycleConfigurationRequestMarshaller : IMarshaller<IRequest, DeleteLifecycleConfigurationRequest> ,IMarshaller<IRequest,Amazon.Runtime.AmazonWebServiceRequest>
	{
		public IRequest Marshall(Amazon.Runtime.AmazonWebServiceRequest input)
		{
			return this.Marshall((DeleteLifecycleConfigurationRequest)input);
		}

        public IRequest Marshall(DeleteLifecycleConfigurationRequest deleteLifecycleConfigurationRequest)
        {
            IRequest request = new DefaultRequest(deleteLifecycleConfigurationRequest, "AmazonS3");

            request.HttpMethod = "DELETE";

            request.ResourcePath = string.Concat("/", S3Transforms.ToStringValue(deleteLifecycleConfigurationRequest.BucketName));
            request.AddSubResource("lifecycle");
            request.UseQueryString = true;
            
            return request;
        }
    }
}
    
