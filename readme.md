This tool "SVNHistorySearcher" is licensed under the "Apache License Version 2.0", see License.txt
The tool "SVNHistorySearcher" was developed in the company exocad GmbH by the author Ion Paciu in 2019.

'''Anleitung:'''

1. Repository ausw�hlen, auf "Change Repository" klicken

2. ins "Find what?" Feld reinschreiben wonach man sucht

3. Wenn n�tig, Datum/Revisionsspanne und Suchoptionen anpassen.
   ( Stop on copy bedeutet, dass nicht in den Dateien, von denen die ausgew�hlten Dateien
   abstammen sucht.
   z.B. wenn man in einem Branch sucht und stop-on-copy AUS ist, wird auch in den Dateien, von denen die Dateien aus dem Branch abstammen, gesucht. )

4. Wenn n�tig, auf Autoren beschr�nken. (Autoren mit Komma getrennt auflisten. Exclude bedeutet, dass nicht in Commits, dieser Autoren gesucht werden soll.)

5. Dateien ausw�hlen in denen gesucht werden soll:
   Das kann man im Baum oder mit dem "Filename" Textfeld machen. Oder mit beiden.

   Beim Textfeld werden alle Dateien durchsucht, die in ihrem Namen den angegebenen String haben und sich unter dem, am Anfang angegebenen Pfad befinden.
   In diesem Fall ist es egal, ob die Datei in einer vorherigen Revision gel�scht wurde und jetzt nicht mehr existiert.

   Man kann auch ein * ins Textfeld eingeben. Das w�re dann eine Suche durch alle Dateien unter dem am Anfang angegebenen Pfad.

   Bei Auswahl �ber das Textfeld, wird stop-on-copy ignoriert, weil es da keinen Sinn ergibt.

   Bei Dateien, die im Baum ausgew�hlt werden, wird standardm��ig in Dateien gesucht, von denen die aktuell ausgew�hlten Dateien abstammen.

6. auf "Find" dr�cken und Geduld haben.
   Erstmal werden alle Diffs zu der Suche vom Server heruntergeladen und lokal gespeichert.
   Das kann, abh�ngig von der Gr��e sehr lange dauern.
   Da der SVNHistorySearcher viele Threads startet um die Diffs ein bisschen schneller herunterzuladen, kann es passieren, das 
   der Server �berlastet wird. Ich empfehle gro�e Anfragen( z.b. das ganze Repository runterladen ) �ber Nacht zu machen.

   Es kann passieren, dass der Ladebalken am Ende sehr lange braucht. Das bedeutet nicht, dass es kaputt ist.

   Die Textsuche, bei schon heruntergeladen Diffs, geht sehr schnell.
   
'''WICHTIG'''
   Bei jeder Suche werden Dateien ignoriert, deren Endung eine Typische, f�r bin�re Dateien ist. (z.B. exe, obj, stl)
   Eine volle Liste befindet sich in der settings.xml

   Der SVNHistorySearcher sucht in �nderung des Inhalts einer Datei:
   Er zeigt nicht alle Revisionen, in denen sich ein bestimmter Text in einer Datei befand, als Ergebnis an.
   Er l�dt sich die Diffs aller Modifikationen und Dateierstellungen runter und sucht nur in Zeilen, die mit einem + oder - beginnen.
   
'''Ergebnisse:'''
   In der Ergebnisliste tauchen Dateien und Ordner auf.

   Wenn sie in gr�ner Textfarbe sind, bedeutet das, dass der Suchtext in ihrem Namen gefunden wurde.

   Wenn sie eine rote Hintergrundfarbe haben, bedeutet das, dass die Datei/der Ordner in der aktuellen Revision nicht mehr existiert.
   Sie ist entweder verschoben worden, wurde umbenannt oder gel�scht.

   Wenn man auf die Datei oder den Ordner klickt, wird im Textfeld rechts die Geschichte dieser Datei angezeigt. (Wann sie erstellt wurde, von wo sie kopiert wurde, ...)

   Bei Dateien werden untergeordnet die einzeilnen Revisionen gezeigt, in denen eine �nderung gefunden wurde.
   Blaue Textfarbe bei einer Revision bedeutet, dass diese �nderung in einer Datei stattfand, von der die jetztige Datei abstammt.

   Mit Doppelklick oder mit dem Button "Open in Tortoise" kann man Dateien in Tortoise �ffnen und sich die �nderung anschauen.
   
'''Sonstiges'''
   Bei der Repository �bersicht gibt es ein Context Menu, mit dem man sich den Inhalt der Dateien ansehen kann.