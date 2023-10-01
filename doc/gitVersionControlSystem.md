# GIT - Version Control System

![TestImage](images/pushPull.drawio.png)

- Central Repository (Zentrale Ablage auf Server)
- Local Repository (Kopie auf eigenem Rechner)
- Push <br>
  Der git push Befehl wird benutzt, um mit einem anderen Repository zu kommunizieren, zu ermitteln, was die lokale Datenbank enthält, die die entfernte nicht hat und dann die Differenz in das entfernte Repository zu pushen.
- Pull <br>
  Der git pull -Befehl wird verwendet, um Inhalte aus einem Remote-Repository herunterzuladen und unverzüglich das lokale Repository zu aktualisieren, damit die Inhalte übereinstimmen.
- Fetch <br>
  Mit dem Befehl git fetch werden Commits, Dateien und Verweise aus einem Remote-Repository in dein lokales Repository heruntergeladen. Das Abrufen ist dann interessant, wenn du wissen willst, woran alle anderen arbeiten.

## Branches

Ein Branch ist ein neuer Zweig für die Entwicklung, wenn man z.B. verschiedene Dinge ausprobieren will, aber
sich noch nicht sicher ist ob Sie schlussendlich verwendent werden.  

Der Master Branch eines Repositorys, auch Main Branch oder Hauptzweig genannt,
enthält den aktuellen Versionsstand einer Software. Von dieser Hauptlinie lassen
sich weitere Branches abzweigen, z. B. zum Entwickeln und Testen (Develop-Branch), und später
wieder mit dem Master Branch verschmelzen.

![TestImage](images/master_dev_branch.png)
##
- Commits <br>
  Mit dem commit-Befehl wird der aktuelle Status des Projekts (Meilenstein) zu diesem Zeitpunkt (auf der Zeitleiste) erstellt (siehe unteres Bild).
- Merge <br>
  Mit git merge werden mehrere Commit-Abfolgen in einen einheitlichen Verlauf zusammengeführt. Vor allem wird git merge genutzt, um zwei Branches zu vereinen.
- dev-Branch (Zweig)

![TestImage](images/branches.drawio.png)