# [Better Time Format (Continued)](https://steamcommunity.com/sharedfiles/filedetails/?id=3377406241)

![Image](https://i.imgur.com/buuPQel.png)

Update of Netrves mod https://steamcommunity.com/sharedfiles/filedetails/?id=2072773208

- Now uses the 12-hour clock setting from the game-preferences instead of a separate mod-option

![Image](https://i.imgur.com/pufA0kM.png)
	
![Image](https://i.imgur.com/Z4GOv8H.png)

# Notice

Due to focus on other project and my lack of interest in RimWorld for now, I'm not maintaining my mods for the time being. They are all open source, so feel free to fork them!

#  Better Time Format 

Turn that boring **18h** to whatever you like! Safe to add and remove to savegames!

Have you ever wanted to see what in-game time your colony is at, but were bothered by that "18h" display?

Well then I have the mod for you! Better Time Format changes the display of the clock to render in a more satisfying way, like "18:05" or "12am" or "8 o'clock" or...whatever! See the minutes and even seconds zoom past when you accelerate your game!

**YOU HAVE THE CONTROL!** You can set up the time display however you like, using simple placeholders you can type in your own preferred time format, ie. "HH:MM" becomes "07:15"! Read the mod settings for more information!

**Note regarding no time:** Just reopen the mod settings menu once, the last update changed where a few internal variables are stored and those need to be updated once.

#  Supported Versions and Requirements 

This mod is made for RimWorld 1.2 and up, and requires Harmony 2.x

#  Parsing and Performance 

The parsing is somewhat simple, on purpose. I traded accuracy for performance, while something like a regular expression would be more accurate, it isn't something you want to use for a game. So please excuse if you sometimes get weird displays with certain inputs. It should work fine for 99% of the cases.

This mod modifies an UI drawing method and on top of that also pulls some strings to get the user format going. I have taken the best precautions I could take to make sure everything runs as optimal as I can see.

The performance at worst is on par with the original function, and sometimes even better, but spikes happen every now and then. Unless something seriously broke, this mod should not be able to pose any problem.

#  Special Thanks 

Thanks to all the helpful people over at the RimWorld Discord who have helped me a lot.

![Image](https://i.imgur.com/PwoNOj4.png)



-  See if the the error persists if you just have this mod and its requirements active.
-  If not, try adding your other mods until it happens again.
-  Post your error-log using [HugsLib](https://steamcommunity.com/workshop/filedetails/?id=818773962) or the standalone [Uploader](https://steamcommunity.com/sharedfiles/filedetails/?id=2873415404) and command Ctrl+F12
-  For best support, please use the Discord-channel for error-reporting.
-  Do not report errors by making a discussion-thread, I get no notification of that.
-  If you have the solution for a problem, please post it to the GitHub repository.
-  Use [RimSort](https://github.com/RimSort/RimSort/releases/latest) to sort your mods

 

[![Image](https://img.shields.io/github/v/release/emipa606/BetterTimeFormat?label=latest%20version&style=plastic&color=9f1111&labelColor=black)](https://steamcommunity.com/sharedfiles/filedetails/changelog/3377406241) | tags:  clock,  format
