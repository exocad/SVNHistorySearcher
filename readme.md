This tool "SVNHistorySearcher" is licensed under the "Apache License Version 2.0", see License.txt
The tool "SVNHistorySearcher" was developed in the company exocad GmbH by the author Ion Paciu in 2019.


# SVNHistorySearcher  
*A tool that allows you to fully search your SVN repository.*  
*You can search your repository for certain filenames*  
*and certain strings in the content changes. (like git's pickaxe)*  
* The most important feature of the tool is, that it will find any strings that ever existed in the repository, even in deleted or renamed or moved files. This does not seem to be possible with any other tool as far as we know. 
* The tool can will build up its own search structure database, such that many fast queries can be done after this initial database build-up phase is finished. 

## Instruction  
1. Select Repository. Click "Change Repository"  

2. Put the string you want to search for in the "Find what?" field  

3. If necessary, change your search options.

4. Select files. This can be done in the tree or file the "Filename" field or both.
   * When using the text field, it will search all files that contain the substring in their name.
   * You can type an \* into the search field and it will search in all files.
   
5. Press "Find" and be patient. It can take a while depending on the size of your query. 
   It downloads the diffs, relevant for your search, and stores them locally. The second search will be faster.  
   It could happen, that the loading bar stays at the end for a very long time. That doesn't mean that it's broken.  

## Search Options  
**Revision Span**  From which to which revision to search. Can be either a date, a number or "HEAD".  

**Case sensitive**  trivial  

**Stop on copy/rename**  If unchecked:  Searcher will search in the selected files and in ancestor files the selected files. If checked: Search will be limited to the selected files.  

**Search in filenames**  If checked: Results will contain files and folders whose name or ancestor names matched the search string in any revision.  
**NOTE:** In order to search your repository for all files with a certain name you have to put an \* in the Filename field.  
**NOTE:** The "stop on copy" option is ignored here because it doesn't make sense here.  

**Search in content changes** If checked: Will in diffs of selected files  
   
**Authors**  Limits the search to commits of certain authors. **Exclude** Excludes commits certain authors have made from search.  

**Filename**  Adds files whose name math this field's text to the search. (eg. type "Dog.cs" to search in all files whose name case insensitivly contains "Dog.cs")  
You can type in an \* to search in all files.  
**NOTE:** This will also search in files that don't exist in the current revision. \-\> you can search in deleted files.  

## Results  
The result list contains files and folders.  
If the text name is **green**, the search string was found in the name.  
If the background color is **red**, the file/folder does not exist in the HEAD revision. It might have been deleted, moved or renamed.  

You can click on each search result to see the history of this file/folder (creation, movements, renames, deletion).  

Search results in the content are listed under the filenames.  
**Blue** text color means that this change in content occered in an ancestor file of this file.  

You can open TortoiseSVN too see die difference by double clicking of clicking the "Open in Tortoise" button.  

## Important  
SVNHistorySearcher only works if you have read-access to the entire repository.  

There is a settings file located at "data/settings.xml". It is created/updated when you close the searcher.  

Files with typical binary file extentions (.exe, .obj, ...) are ignored. A full list can be found the "settings.xml".  

The Searcher searches in content changes:  
It downloads the diffs and searches for the string in lines that start with a \+ or \-.  
It does not show you which revisions contained your search string. But you can easily get to that by looking at the results.

## Things that can happen  
The downloading process seems to be going really fast but then it restarts with about the same "unified diffs" to download 3 times and then tells you that many files are missing from search.  
This is because some subversion servers block clients that send multiple request in parallel for too long.  

**Solution:**  
Close SVNHistorySearcher.  
Open your "settings.xml" in the "data" folder.  
Set MaxFetchingThreads to 1.  
Wait a bit.  
Open SVNHistorySearcher and try again.  

## Miscelleaneous
   You can open files from the repository overview by right clicking on them and selecting "Open".
