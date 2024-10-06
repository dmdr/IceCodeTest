To run the application using default input
==========================================
Running (from the IceCodeTest sub-folder) - The $ symbol indicates the prompt and should not be entered

$ dotnet run

-- Output
ICE Code Test
Runing default tests:

Subtext: Polly
Output: 1, 26, 51

Subtext: polly
Output: 1, 26, 51

Subtext: ll
Output: 3, 28, 53, 78, 82

Subtext: Ll
Output: 3, 28, 53, 78, 82

Subtext: X
Output: <no matches>

Subtext: Polx
Output: <no matches>
-------------------



Run taking input from a text file (see IceCodetest/search.txt for example):
===========================================================================
Note: The text file is in the following format:
      First line is the subtext to search for (Polly for example), and 
      the rest of the file is input text (text to be searched)

Running (using search.txt):

$ dotnet run "-f search.txt"



Test Harness:
=============
To Run using the MSTest harness (From the root folder where the IceCodeTestSolution.sln file is located) 
running:

$ dotnet test


Test Sample output:
Passed!  - Failed:     0, Passed:    19, Skipped:     0, Total:    19, Duration: 90 ms - TestIceCodeTest.dll (net7.0)
