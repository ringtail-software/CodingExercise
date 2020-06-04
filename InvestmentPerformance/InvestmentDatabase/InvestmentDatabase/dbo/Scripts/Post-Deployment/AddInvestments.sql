GO
IF NOT EXISTS (Select 1 from Investments where Name='Nuix')
Begin
  Insert into Investments 
  Values ('Nuix', 1)
End

IF NOT EXISTS (Select 1 from Investments where Name='PPG')
Begin
  Insert into Investments 
  Values ('PPG', 1)
End

IF NOT EXISTS (Select 1 from Investments where Name='Google')
Begin
  Insert into Investments 
  Values ('Google', 1)
End