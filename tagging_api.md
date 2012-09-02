# Objects

## Tag

A tag is the key object for Tagging, it represents a string of text (up to 50 characters) entered by a user, on a post, and when it was entered.

### Example Tag object

```js
{
	"Id":1
	,"PostId":"1"
	,"UserId":"2"
	,"Text":"Test Tag"
	,"TimeStamp":"\/Date(1346557542680)\/"
}
```

### User fields

<table>
    <tr>
        <th>Field</th>
        <th>Type</th>
        <th>Description</th>
    </tr>
    <tr>
        <td><code>Id</code></td>
        <td>int</td>
        <td>This is the unique Id of the Tag, and will be generated by the server when creating or reading tags</td>
    </tr>
    <tr>
        <td><code>PostId</code></td>
        <td>string</td>
        <td>This is the App.net post `id` for this tag (<a href='https://github.com/appdotnet/api-spec/blob/master/objects.md#post-fields'>post object spec</a>).</td>
    </tr>
    <tr>
        <td><code>UserId</code></td>
        <td>string</td>
        <td>This is the App.net user `id` for this tag (<a href='https://github.com/appdotnet/api-spec/blob/master/objects.md#user-fields'>user object spec</a>).</td>
    </tr>
    <tr>
        <td><code>Text</code></td>
        <td>string</td>
        <td>The text of the tag, can be any string up to 50 characters long.  Anything longer than 50 characters will be cut-off.</td>
    </tr>
    <tr>
        <td><code>TimeStamp</code></td>
        <td>DateTime</td>
        <td>The date and time the tag was saved.  This is using the <a href='http://weblogs.asp.net/bleroy/archive/2008/01/18/dates-and-json.aspx'>Microsoft escapped format</a>.</td>
    </tr>
</table>

## Create a Tag
Create a new Tag by sending JSON in the HTTP-POST body containing the `PostId`, `UserId`, and `Text` above.  Your `Request` must have an HTTP header of ```Content-Type: application/json```.

### URL
> http://rapptormods.azurewebsites.net/tags

### Example

> POST http://rapptormods.azurewebsites.net/tags
> Content-Type: application/json
> DATA '{"PostId":"1","UserId":"2","Text":"Test Tag"}'

## Delete a Tag
Deletes an instance of a tag on a post.

### URL
> http://rapptormods.azurewebsites.net/tags/[Id]

### Data

<table>
    <thead>
        <tr>
            <th>Name</th>
            <th>Required?</th>
            <th>Type</th>
            <th>Description</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td><code>Id</code></td>
            <td>Required</td>
            <td>int</td>
            <td>The id of the tag being deleted</td>
        </tr>
    </tbody>
</table>

### Example

> DELETE http://rapptormods.azurewebsites.net/tags/1

```js
	"Id":1
	,"PostId":"1"
	,"UserId":"2"
	,"Text":"Test Tag"
	,"TimeStamp":"\/Date(1346557542680)\/"
```

## Get Tags by Post
Retrieves a list of tags on a given post.  Be aware that there will be duplicates if the tag's text matches, this is expected and helps to rank the tag (e.g. 10 instances of "like" give the "like" tag a rank of 10).

### URL
> http://rapptormods.azurewebsites.net/tags/by-post/[PostId]

### Data

<table>
    <thead>
        <tr>
            <th>Name</th>
            <th>Required?</th>
            <th>Type</th>
            <th>Description</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td><code>PostId</code></td>
            <td>Required</td>
            <td>string</td>
            <td>The PostId to retrieve tags for.</td>
        </tr>
    </tbody>
</table>

### Example

> GET http://rapptormods.azurewebsites.net/tags/by-post/1

```js
	{
		"Tags":[
				{"Id":4,"PostId":"777","UserId":"1","Text":"Tag","TimeStamp":"\/Date(1346562804873)\/"}
				,{"Id":5,"PostId":"777","UserId":"2","Text":"Tag2","TimeStamp":"\/Date(1346562806090)\/"}
				]
	}
```

## Get Tags by User
Retrieves all the tags made by a given user.

**WARNING!**
This will likely return a HUGE data-set, and is only for testing right now.  Please use with EXTREME care until the amount of data returned gets reduced.

### URL
> http://rapptormods.azurewebsites.net/tags/by-user/[UserId]

### Data

<table>
    <thead>
        <tr>
            <th>Name</th>
            <th>Required?</th>
            <th>Type</th>
            <th>Description</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td><code>UserId</code></td>
            <td>Required</td>
            <td>string</td>
            <td>The UserId to retrieve tags for.</td>
        </tr>
    </tbody>
</table>

### Example

> GET http://rapptormods.azurewebsites.net/tags/by-user/1

```js
	{
		"Tags":[
				{"Id":4,"PostId":"3","UserId":"1","Text":"Tag","TimeStamp":"\/Date(1346562804873)\/"}
				,{"Id":5,"PostId":"4","UserId":"1","Text":"Tag2","TimeStamp":"\/Date(1346562806090)\/"}
				]
	}
```