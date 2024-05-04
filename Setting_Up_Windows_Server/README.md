# Setting up Windows Server
## Installation
### 1. Create a new directory (for example C:\FXServer\server), this will be used for the server binaries.
### 2. Download the current recommended master branch build for Windows from the Windows server build listing.
### 3. Extract the build into the directory previously created.
### 4. Clone cfx-server-data in a new folder outside of your server binaries folder, for example, C:\FXServer\server-data.
```
git clone https://github.com/citizenfx/cfx-server-data.git server-data
```
&nbsp;&nbsp; *To type this command you need to open a command prompt, press Win + R, once the run dialog shows type cmd and hit enter,<br/>*
&nbsp;&nbsp; *remember to switch directories to the directory you plan to clone to by typing cd C:\FXServer.*
### 5. Make a server.cfg file in your server-data folder (copy the example server.cfg file below into that file).<br/>
&nbsp;&nbsp;server.cfg
```
# Only change the IP if you're using a server with multiple network interfaces, otherwise change the port only.
endpoint_add_tcp "0.0.0.0:30120"
endpoint_add_udp "0.0.0.0:30120"

# These resources will start by default.
ensure mapmanager
ensure chat
ensure spawnmanager
ensure sessionmanager
ensure basic-gamemode
ensure hardcap
ensure rconlog

# This allows players to use scripthook-based plugins such as the legacy Lambda Menu.
# Set this to 1 to allow scripthook. Do note that this does _not_ guarantee players won't be able to use external plugins.
sv_scriptHookAllowed 0

# Uncomment this and set a password to enable RCON. Make sure to change the password - it should look like rcon_password "YOURPASSWORD"
#rcon_password ""

# A comma-separated list of tags for your server.
# For example:
# - sets tags "drifting, cars, racing"
# Or:
# - sets tags "roleplay, military, tanks"
sets tags "default"

# A valid locale identifier for your server's primary language.
# For example "en-US", "fr-CA", "nl-NL", "de-DE", "en-GB", "pt-BR"
sets locale "root-AQ" 
# please DO replace root-AQ on the line ABOVE with a real language! :)

# Set an optional server info and connecting banner image url.
# Size doesn't matter, any banner sized image will be fine.
#sets banner_detail "https://url.to/image.png"
#sets banner_connecting "https://url.to/image.png"

# Set your server's hostname. This is not usually shown anywhere in listings.
sv_hostname "FXServer, but unconfigured"

# Set your server's Project Name
sets sv_projectName "My FXServer Project"

# Set your server's Project Description
sets sv_projectDesc "Default FXServer requiring configuration"

# Set Game Build (https://docs.fivem.net/docs/server-manual/server-commands/#sv_enforcegamebuild-build)
#sv_enforceGameBuild 2802

# Nested configs!
#exec server_internal.cfg

# Loading a server icon (96x96 PNG file)
#load_server_icon myLogo.png

# convars which can be used in scripts
set temp_convar "hey world!"

# Remove the `#` from the below line if you want your server to be listed as 'private' in the server browser.
# Do not edit it if you *do not* want your server listed as 'private'.
# Check the following url for more detailed information about this:
# https://docs.fivem.net/docs/server-manual/server-commands/#sv_master1-newvalue
#sv_master1 ""

# Add system admins
add_ace group.admin command allow # allow all commands
add_ace group.admin command.quit deny # but don't allow quit
add_principal identifier.fivem:1 group.admin # add the admin to the group

# enable OneSync (required for server-side state awareness)
set onesync on

# Server player slot limit (see https://fivem.net/server-hosting for limits)
sv_maxclients 48

# Steam Web API key, if you want to use Steam authentication (https://steamcommunity.com/dev/apikey)
# -> replace "" with the key
set steam_webApiKey ""

# License key for your server (https://keymaster.fivem.net)
sv_licenseKey changeme
```
### 6. Set the license key in your server.cfg using sv_licenseKey "licenseKeyGoesHere".
### 7. Run the server from the server-data folder. For example, in a plain Windows command prompt (cmd.exe) window:
```
cd /d C:\FXServer\server-data
C:\FXServer\server\FXServer.exe +exec server.cfg
```
&nbsp;&nbsp; *the /d flag is only needed when changing directory to somewhere on a different drive*