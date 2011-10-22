Search Party API
===

**TODO:**

 - search - thinking criteria api stuff
 - api (adding of resources etc)
 - ioc container
 - define command pattern

**Example URI**
 - ```http://searchparty-1.apphb.com/search```

 ---
URI: ```/search/?q=```
Methods: ```GET```
Parameters: ```q```
 = free text. tags identified by ^ prefix
Returns:
Json array of results like

```json
[{
id = ''
uri = ''
title = ''
tags = ''
shortDescription = ''
longDescription = ''
resourceType = ''
},
]
```


WIP from here
===
resource

Methods: ```GET / PUT / POST / DELETE```
Parameters: ```id```
 = identifier of the resource
Returns:
Json resource entity

```json
[{
id = ''
uri = ''
title = ''
tags = ''
shortDescription = ''
longDescription = ''
resourceType = ''
}
]
```

ID is auto generated GUID.

----------------------------------------------------------
resourceList

Methods: ```GET```
Returns:
Json array of resources like

```json
[{
id = ''
uri = ''
title = ''
tags = ''
shortDescription = ''
longDescription = ''
resourceType = ''
}
]
```

ID is auto generated GUID.

----------------------------------------------------------
category		 

Methods: ```GET / PUT / POST / DELETE```
Parameters: ```id```
 = identifier of the category
Returns:
Json category entity

```json
[{
id = ''
title = ''
blub = ''
tags = ''
parent = ''
searchResultLinks = ''
subCategories = ''
}
]
```

ID is auto generated GUID.
searchResultLinks is a list of searchResultLinks - SEPARATE?
subCategories is a list of categories nested within this category - SEPARATE?

----------------------------------------------------------

topLevelCategoryList	 

Methods: ```GET```
Returns:
Json array of the top level categories like

```json
[{
id = ''
title = ''
blub = ''
tags = ''
searchResultLinks = ''
subCategories = ''
},
]
```

searchResultLinks is a list of searchResultLinks
subCategories is a list of categories nested within this category

----------------------------------------------------------

Resource/Update

Methods: ```POST```
Returns:
Json object of the created/updated resource, or error details
n.b. to create a new resource, set the id property to 0. To update, use the existing id.

```json
{
id = ''
uri = ''
title = ''
tags = ''
shortDescription = ''
longDescription = ''
resourceType = ''
}

```
