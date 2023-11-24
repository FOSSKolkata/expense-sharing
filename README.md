# Low-level design of an expense-sharing application like Splitwise

I came across this blog https://workat.tech/machine-coding/editorial/how-to-design-splitwise-machine-coding-ayvnfo1tfst6 that describes the problem statement of designing an Expense Sharing application like Splitwise. 

This code repository is C# version of the code presented there with some improvements. The most important one is the initialization of Splits. Let me give you a brief background. 

A user can add an expense to the app specifying its type: equal, exact, and percent, the total amount spent, a list of users among which expense needs to be split, and other parameters depending upon the type of the expense. For details, please read the problem statement from the aforementioned blog.

When we get down to identifying the entities and their attributes, we would find out that there should be a class for Expense and that it should contain an attribute for Splits (which contains the information of how the expense is split into partakers). Where does the initialization of Splits belong? Intuitively, the initialization of Splits belongs to containing class Expense and nowhere else. This is one of the improvements that I did. I moved the initialization of Splits from the Main or Driver class to the sub-classes inheriting the Expense class. I felt the Main or Driver class only should have the responsibility of reading inputs from a user and then passing them to the ExpenseManager (please see the code) and should not bother much about initializing Splits for an expense.

The expense class declares the abstract method InitSplits which enforces each subclass of Expense (EqualExpense, ExactExpense, and, PercentExpense) to provide specific implementation of the method. Note, that the [ExpenseFactory](https://github.com/FOSSKolkata/expense-sharing/blob/main/SplitWiseDesign/ExpenseFactory.cs) class creates an instance of a subclass of Expense and also makes a call to the InitSplits method defined within it.   

As of now (24 Nov 2023), there are some improvements pending, like proper encapsulation, unit tests, etc, which I hope to do in the future.     




