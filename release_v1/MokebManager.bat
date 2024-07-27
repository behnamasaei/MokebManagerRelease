::[Bat To Exe Converter]
::
::YAwzoRdxOk+EWAjk
::fBw5plQjdCyDJGyX8VAjFDlRRAqDMVeXCb4Z6sX64euAp18vUe46eZze5qaLLOUS+UDbY8cR13RdjccNHhpIbi64fAwIqH1Rs3CWC86fvAHydkmd50kxDyh4jmTYmGUyY9wI
::YAwzuBVtJxjWCl3EqQJgSA==
::ZR4luwNxJguZRRnk
::Yhs/ulQjdF+5
::cxAkpRVqdFKZSzk=
::cBs/ulQjdF+5
::ZR41oxFsdFKZSDk=
::eBoioBt6dFKZSDk=
::cRo6pxp7LAbNWATEpCI=
::egkzugNsPRvcWATEpCI=
::dAsiuh18IRvcCxnZtBJQ
::cRYluBh/LU+EWAnk
::YxY4rhs+aU+JeA==
::cxY6rQJ7JhzQF1fEqQJQ
::ZQ05rAF9IBncCkqN+0xwdVs0
::ZQ05rAF9IAHYFVzEqQJQ
::eg0/rx1wNQPfEVWB+kM9LVsJDGQ=
::fBEirQZwNQPfEVWB+kM9LVsJDGQ=
::cRolqwZ3JBvQF1fEqQJQ
::dhA7uBVwLU+EWDk=
::YQ03rBFzNR3SWATElA==
::dhAmsQZ3MwfNWATElA==
::ZQ0/vhVqMQ3MEVWAtB9wSA==
::Zg8zqx1/OA3MEVWAtB9wSA==
::dhA7pRFwIByZRRnk
::Zh4grVQjdCyDJGyX8VAjFDlRRAqDMVeXCb4Z6sX64euAp18vUe46eZze5qaLLOUS+UDbY8cRb5ziSXLpTKOfx/MTvLfzEb8CD4E9+HxwC95apvBDpvLVoo3OTtsYzJPv2TTQVXvEaMz+RaxHWBz4ab+xW7ELdQ==
::YB416Ek+ZG8=
::
::
::978f952a14a936cc963da21a135fa983
 @echo off



echo Starting Host...
rem Start the ping command in a new thread
start "" cmd /c "cd ./angularapp && yarn start"

echo Starting Server...
rem Any other commands
start "" cmd /c "cd ./dotnetapp && dotnet ./MokebManagerNg.HttpApi.Host.dll --urls=https://0.0.0.0:44355"


echo Set IP...
start "" ".\SetIp.exe"

pause
