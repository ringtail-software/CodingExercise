GO
IF NOT EXISTS (Select 1 from Transactions where UserGuid='20ce3647-fcac-4d65-a1b0-dd729303d7e4')
Begin
  Insert into Transactions
  Values ('20ce3647-fcac-4d65-a1b0-dd729303d7e4', 1, 20.45, '1/22/2020', 34), 
  ('20ce3647-fcac-4d65-a1b0-dd729303d7e4', 2, 62.12, '1/2/2018',20)
End


IF NOT EXISTS (Select 1 from Transactions where UserGuid='fa0eb10e-1930-460e-9252-f4725ed2e55d')
Begin
  Insert into Transactions
  Values ('fa0eb10e-1930-460e-9252-f4725ed2e55d', 2, 60.00, '1/30/2019', 66)
End


IF NOT EXISTS (Select 1 from Transactions where UserGuid='c2cd755a-a39f-416b-86ba-f3253acb5f2d')
Begin
  Insert into Transactions
  Values ('c2cd755a-a39f-416b-86ba-f3253acb5f2d', 3, 10.50, '4/01/2019', 25),
   ('c2cd755a-a39f-416b-86ba-f3253acb5f2d', 1, 80.50, '4/01/2015',7),
   ('c2cd755a-a39f-416b-86ba-f3253acb5f2d', 2, 2.88, '3/01/2020', 43)
End


