anmerkungen:

1.
connectionstring: passiert automatisch in webconfig 
durch anlegen controller mit ef
db context wird automatisch erstellt 
(alle tabellen der loesung inkludiert)


2.
migrationen (anderungen code/datenschema):
1. (einmalig): Enable-Migrations
2. Add-Migration
3. Update-Database

spaeter dann moeglich in /Migrations/Configuration.cs
AutomaticMigrationsEnabled = true
