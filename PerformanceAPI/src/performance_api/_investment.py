from dataclasses import dataclass

@dataclass
class Investment:
    name: str
    id: int

@dataclass
class Summary:
    numberOfShares: int
    costBasis: int
    currentPrice: int
    currentValue: int
    gainLoss: int
    term: str

    def __post_init__(self):
        self.term = "long" if bool(self.term) else "short"
