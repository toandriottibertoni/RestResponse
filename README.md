## **RestResponse**
  
In order to reuse code, facilitate and speed up a definition of http status code for api rest.
At the moment I don't have much to say, I believe that the examples speak for themselves.
****
**Package**

[Nuget](https://www.nuget.org/packages/RestResponse/)

![Nuget](https://img.shields.io/nuget/dt/RestResponse?style=flat-square)

**Install:**

Package Manager
>Install-Package RestResponse

NET CLI
> dotnet add package RestResponse

***
**Expample:**

**Return treatment of a fruit list with RestResponde:**

    [HttpGet("rest-response/{fruitName}")]
    public  IActionResult  GetWithRestResponse(string  fruitName)
    {    
	    return _service.FilterWithResponse(fruitName).RestResponse<List<Fruit>>(this);
    }


**Return treatment of a fruit list with RestResponde with custom codes:**

    [HttpGet("rest-response/{fruitName}")]    
    public  IActionResult  GetWithRestResponse(string  fruitName)
    {
		 return _service.FilterWithResponse(fruitName).RestResponse<List<Fruit>>(this,
                                                                             HtpStatusCode.OK,
                                                                             HttpStatusCode.NotFound);
    }

**Return object handling with RestResponde:**

    [HttpGet("rest-response-object/{id}")]
    public  IActionResult GetWithRestResponseObject(int id)
    { 
	    return _service.FilterWithResponseObject(id).RestResponse<Fruit>(this);
    }


**Return object handling with RestResponde with custom codes:**

    [HttpGet("rest-response-object/{id}")]    
    public  IActionResult  GetWithRestResponseObject(int  id)
    
    {    
	    return _service.FilterWithResponseObject(id).RestResponse<Fruit>(this,
	                                                                     HttpStatusCode.OK,
	                                                                     HttpStatusCode.NotFound);
   
    }

**Return object handling with RestResponde with function to check if empty:**

    [HttpGet("rest-response-object/{id}")]
    public  IActionResult  GetWithRestResponseObject(int  id)
    {    
	    Func<Fruit, bool> isEmpty =  fruit  => string.IsNullOrWhiteSpace(fruit.name);    
	    return _service.FilterWithResponseObject(id).RestResponse<Fruit>(this, isEmpty);
    }
