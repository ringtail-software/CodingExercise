from setuptools import setup, find_packages

setup (
    name             = "performance_api",
    version          = "1.0",
    description      = "Investment web performance API.",
    package_dir      = {"": "src"},
    packages         = find_packages("src") + ["twisted.plugins"],
    install_requires = ["twisted>=20.3.0",
                        "klein>=20.6.0",
                        "treq>=20.4.1"]    
)
