CREATE TABLE IF NOT EXISTS Account (
       AccountId INTEGER PRIMARY KEY
);

CREATE TABLE IF NOT EXISTS Company (
       CompanyId INTEGER PRIMARY KEY,
       Symbol TEXT NOT NULL UNIQUE,
       Name TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Instrument (
       InstrumentId INTEGER PRIMARY KEY,
       Timestamp DATETIME NOT NULL,
       Price INTEGER NOT NULL,
       CompanyId INT,
       FOREIGN KEY(CompanyId) REFERENCES Company
);

CREATE TABLE IF NOT EXISTS Investment (
       InvestmentId INTEGER PRIMARY KEY,
       Quantity INTEGER NOT NULL,
       InstrumentId INT,
       AccountId INT,
       FOREIGN KEY(InstrumentId) REFERENCES Instrument(InstrumentId),
       FOREIGN KEY(AccountId) REFERENCES Account(AccountId)
);
