# SARENZA - backend dotnet

## Objectifs
- Voir comment tu codes dans la vrai vie :D
- Faire une PR sur la master pour qu'on puisse te faire des retours

## Consigne
Dans le cadre de ce projet, nous souhaitons avoir une api :

1. Je veux que mon sensor récupère la température provenant du composant TemperatureCaptor (renvoi la température en °C)
2. Je veux que l'état de mon Sensor soit à "HOT" lorsque la température captée est suppérieure ou égale a 40 °C.
3. Je veux l'état de mon Sensor soit à "COLD" lorsque la température captée est inferieur a 22 °C.
4. Je veux l'état de mon Sensor soit à "WARM" lorsque la température captée est entre 22 et inferieur à 40 °C.
5. Je veux récuperer l'historique des 15 dernieres demandes des températures.
6. Je veux pouvoir redefinir les limites pour "HOT", "COLD", "WARM"


**Stack mandatory**: .NET CORE, SQL Lite, docker