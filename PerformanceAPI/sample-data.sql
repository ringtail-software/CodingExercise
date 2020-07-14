-- placeholder data for demonstration
BEGIN;

INSERT INTO Account (AccountId) VALUES (1), (2), (3);

INSERT INTO Company (Symbol, Name) VALUES ('GOOG', 'Alphabet Inc.'),
                                          ('AMZN', 'Amazon.com Inc.'),
                                          ('KO', 'Coca-Cola Co.'),
                                          ('GE', 'General Electric Co.'),
                                          ('AXP', 'American Express Co.');

INSERT INTO Instrument (CompanyId, Price, Timestamp) VALUES (1, 1170, '2020-07-06 07:16:16'),
       	    	       		   	  	     	    (1, 650, '2020-07-07 07:16:16'),
							    (1, 760, '2020-07-08 07:16:16'),
							    (1, 590, '2020-07-09 07:16:16'),
							    (1, 1480, '2020-07-10 07:16:16');
INSERT INTO Instrument (CompanyId, Price, Timestamp) VALUES (2, 1960, '2020-07-06 07:16:16'),
       	    	       		   	  	     	    (2, 1940, '2020-07-07 07:16:16'),
							    (2, 2570, '2020-07-08 07:16:16'),
							    (2, 3340, '2020-07-09 07:16:16'),
							    (2, 2290, '2020-07-10 07:16:16');
INSERT INTO Instrument (CompanyId, Price, Timestamp) VALUES (3, 6330, '2020-07-06 07:16:16'),
       	    	       		   	  	     	    (3, 6200, '2020-07-07 07:16:16'),
							    (3, 5850, '2020-07-08 07:16:16'),
							    (3, 3770, '2020-07-09 07:16:16'),
							    (3, 4090, '2020-07-10 07:16:16');
INSERT INTO Instrument (CompanyId, Price, Timestamp) VALUES (4, 7890, '2020-07-06 07:16:16'),
       	    	       		   	  	     	    (4, 6660, '2020-07-07 07:16:16'),
							    (4, 6720, '2020-07-08 07:16:16'),
							    (4, 7470, '2020-07-09 07:16:16'),
							    (4, 7520, '2020-07-10 07:16:16');
INSERT INTO Instrument (CompanyId, Price, Timestamp) VALUES (5, 9080, '2020-07-06 07:16:16'),
       	    	       		   	  	     	    (5, 9630, '2020-07-07 07:16:16'),
							    (5, 8010, '2020-07-08 07:16:16'),
							    (5, 9060, '2020-07-09 07:16:16'),
							    (5, 9560, '2020-07-10 07:16:16');

INSERT INTO Investment (Quantity, InstrumentId, AccountId) VALUES (15, 22, 1), (8, 24, 1), (100, 7, 1);

COMMIT;
