# RewardPointCalculator

* Checkout the Git repo RewardPointCalculator on your windows system
* The application has three test cases written in,
   * TransactionAmount.txt, which is a test case with no errors. It contains 30 transaction records
   * TransactionAmountInvl.txt, which contains a test case with errors, errors injected on invalid transaction amount
   * TransactionAmountInvl1.txt, which contains an empty file
* In order to run the application, please follow the steps below,
   * Open windows command prompt and change directory to <Application_path>RewardPointCalculator/bin/release/net6.0
   * Run RewardPointCalculator <Test Case File Name>, eg: RewardPointCalculator TransactionAmount.txt
* Once you run the above command, if test is run succesfully with out any errors, you should see a log in the console for all the transactions and associated reward points
* If there are errors, you would see respective exceptions/error message
