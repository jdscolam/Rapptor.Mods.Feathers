RapptorMods
--

A collection of API Modifications for the App.net API.

Release Notes
--
**Version 0.1**
- Initial Release (VERY ALPHA!)
- Added the Tagging Mod (VERY ALPHA!)
- Added API documentation for the Tagging Mod
- Added an API wrapper for the Tagging Mod for .NET (Rapptor.Mods.Feathers.Tagging)

What are RapptorMods?
--

If you look at App.net as though it were like Minecraft, RapptorMods are like Minecraft Mods.  They are extensions and modifications to the core App.net API that allow you to do cool things.

The first Mod is Tagging, allowing you to mark a post with any text you want.  For example, you could mark a lol-cats post as "Funny", or a post about a good restaurant as "Food".
You can use multiple tags on a post, such as "like", "neat", "favorite".  Anyone can tag a post, and people can tag a post with the same thing (e.g. @po "likes" a post, and so does @clapson).
The opportunities are endless ^_^!

RapptorMods are mostly for Thrid-Party developers, so it may take a bit before they appear in your favorite App.net client.

In order to use Tagging, or any other Mod, all a developer needs to do is make the appropriate HTTP calls.  The current server is live at http://rapptormods.azurewebsites.net.

**WARNING**
The Tagging Mod and API is currently live, but VERY ALPHA, and will be subject to change soon, particularly reducing the amount of data that can be returned.  Please use carefully.

Please see the API markdown documents for further information.

Please see this blog entry for a broader introduction to RapptorMods, and where I am going with this: http://jdscolam.blogspot.com/2012/09/rapptormods-and-my-appnet-dreams.html

Input Needed (and Pull-Requests Accepted)
--

1. Any thoughts or suggestions on the direction of the Tagging Mod API
1. Any thoughts or ideas on future RapptorMods
1. Any thoughts or ideas on monetization to pay for hosting and further development

Coming Soon
--

1. Better whitespace handling around tags
1. Ensure that a user can only delete their own tags
1. Allowing a user to only add a tag once
1. Reducing the number of tags returned to a managable number (~20 or so)
1. Getting a list of unique posts that have a given tag
1. Tag clouds on posts, including counts
1. Identifying which tags within a tag cloud were added by a specific user
1. Saving tags to search by (e.g. I want to save a tag named Favorites and get a stream of posts for that tag)
1. Saving posts to saved tags (e.g. I want to save a post to look up for later related to Cats)
1. More awesomeness...


Credit Where it is Due
--

Lots of #highfives for @elmofromok, @lucypepper, @po, @q, @clapson, @elyse, @trine, @aphroditesoftwr, and others for beliving in me and giving me ideas.

Lots of thanks for @mas for keeping me musically inspired during the project.

Thanks to the FubuMVC and StructureMap guys for giving me some awesome products to use.

Thanks for @dalton and his team for creating the App.net platform.

Most importantly, thank you to my wife and daughter for putting up with me, and letting daddy pursue his dreams.

#MondayNightDanceParty FTW!

Copyrights
--

Copyright Jonathan Scolamiero, 2012

Bottom Line
--

We shall be slaves no longer!