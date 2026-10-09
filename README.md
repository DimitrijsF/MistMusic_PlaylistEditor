# MistMusic Playlist Editor
**A Windows desktop utility for creating and editing playlists for [MistMusic](https://github.com/DimitrijsF/MistMusic).**
MistMusic Playlist Editor is a companion application for MistMusic, an ESP32-based MP3 player designed to replace the original internal CD drive of the Opel CD30 MP3 head unit.
The application makes it easy to create and manage music playlists directly on a USB flash drive without manually editing text files.

## Features

- **USB drive detection** — automatically detects available removable drives.
- **Music library browsing** — scans the selected drive for MP3 files, including files in subdirectories.
- **Playlist creation** — create new playlists with custom names.
- **Playlist editing** — open existing playlists and modify their contents.
- **Track management** — add tracks to a playlist or remove them using double-click.
- **Direct saving** — save playlists directly to the selected USB drive.
- **Missing file detection** — warns when a playlist references files that are no longer available.
- **Playlist deletion** — delete a playlist and its associated index file.

## How It Works
MistMusic uses plain-text playlist files with the `.plst` extension.
Each playlist contains one music file path per line. Playlist files must be stored in the root directory of the USB drive, while music files can be organized into subdirectories.
For example, a playlist named `Rock.plst` might contain:

```text
/usb/Music/ACDC/01.mp3
/usb/Music/Metallica/02.mp3
/usb/Music/Rammstein/03.mp3
```

The `/usb/` prefix represents the USB filesystem as seen by the MistMusic firmware.
The Playlist Editor converts between Windows filesystem paths and the paths expected by MistMusic when loading and saving playlists.

### Playlist Index Files
MistMusic generates its own binary `.idx` files when scanning the USB drive.
These files are used internally by the player to access playlist tracks efficiently. The Playlist Editor does not need to create or maintain them.
When deleting a playlist, the application also removes its corresponding `.idx` file, if present.

## Getting Started

### Requirements
- Windows
- Microsoft Visual Studio with Windows Forms development support
- .NET Framework 4.7
- A USB flash drive containing MP3 files

### Building from Source
1. Clone or download this repository.
2. Open `MM_PlaylistEditor.sln` in Visual Studio.
3. Build the solution.
4. Run the application.

### Creating a Playlist
1. Connect your USB flash drive to the computer.
2. Launch MistMusic Playlist Editor.
3. Select the USB drive from the device list.
4. Click the button to create a new playlist.
5. Enter a name for the playlist.
6. Browse the available MP3 files in the music library.
7. Double-click a file to add it to the playlist.
8. Double-click a file in the playlist to remove it.
9. Click **Save** to write the playlist to the USB drive.

The playlist is saved as a `.plst` file in the root directory of the selected drive.

### Editing an Existing Playlist
1. Connect the USB drive containing your playlists.
2. Select the drive in the application.
3. Choose an existing playlist from the playlist list.
4. Add or remove tracks as needed.
5. Click **Save** to apply the changes.

The application warns you if a playlist references files that cannot be found on the selected drive.

## Compatibility
MistMusic Playlist Editor is designed to work with USB playlist files used by the [MistMusic firmware](https://github.com/DimitrijsF/MistMusic).

For correct operation:
- Keep `.plst` files in the root directory of the USB drive.
- Make sure playlist entries refer to files that exist on the drive.
- Use MP3 files supported by the MistMusic player.
- Allow MistMusic to generate its own `.idx` files when the USB drive is connected to the player.

## Related Project

### MistMusic
MistMusic is an ESP32-based USB MP3 player that emulates the original internal CD drive of the Opel CD30 MP3 head unit.
The project aims to preserve the factory head unit and its original user interface while adding USB music playback and support for further audio sources.
Repository: [DimitrijsF/MistMusic](https://github.com/DimitrijsF/MistMusic)

## License and Usage
This project is provided for personal and non-commercial use.
You are free to use, modify, and share the software, provided that it is not sold or distributed as a commercial product.
Commercial sale of the software, including modified versions, is not permitted without the author's permission.

## Project Status
MistMusic Playlist Editor is a companion utility for the MistMusic project.
The application is developed alongside the player firmware, and its functionality may evolve as the MistMusic project progresses.
