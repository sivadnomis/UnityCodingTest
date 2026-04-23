# Coding Test - Sing King

## Brief
This coding test simulates a real-world daily working scenario. Your task is to implement a UI screen for a rewards gallery that allows the user to choose from different reward items. Whilst inspired by a real feature in our application, we have adapted and reduced the scope to fit a smaller time window.

### Goal

UI interaction reference video:

[InteractionSample.mp4](InteractionSample.mp4)

We would like you to implement an extensible scrolling list showing reward items based on the provided data, matching the interaction sample shown in the video above. 

In our real app, the rewards catalogue would be defined and provided by an online live-ops service, however we would like you to create a mock service in Unity that uses scriptable objects to define the reward catalogue. See the **Data** section for a list of items in the catalogue. Note that there are both single reward items and bundle reward items, which contain 1-4 single items.

We would then like you to retrieve the data from the service to populate the list. It is up to you to decide how to configure dependencies between the data and the UI. It is also up to you to make the necessary modifications to the provided art assets in order for the list to display both reward types. 

#### Summary

1. Your UI and interaction should match that of the interaction sample shown in the video above
   1. When an item is selected, please log that item to the console
   2. Whilst the sample project simulates a portrait mobile screen (1920x1080), we will be testing your project in the editor, so mouse interaction is acceptable
2. You should create a service with data mocked via scriptable objects to match the provided rewards catalog
    1. Your implementation should allow for us to add new item types or remove existing items from the list.
3. See the *Submission* section for important notes on working with git, and how we would like you to provide your completed test.

### Assets

In the provided zip folder you will find: 
1. Git Repository 
2. Unity Project (Unity 6.3 LTS)
   1. `Rewards Screen.unity`
   2. `Assets/Prefabs/Item.prefab`
   3. `Assets/Images/Items`

- Please implement your changes in the `Rewards Screen` scene (`2.i`).
- The artist has provided you with a template item prefab (`2.ii`), 
  - You are free to modify or derive this prefab in any way you deem necessary. 
- The images you need to fulfill the different item types can be found in the images folder (`2.iii`). 

### Data

The product team has provided you with the following Item catalogue they would like to see in the rewards screen. 

Note:
- An item can have a quantity (e.g. lives x 5 ) or it can be an individual item without a quantity (e.g. cosmetic)
- There are both single items, and bundles composed of multiple single items
  - It is agreed that bundles shouldn't have more than four items 
  - Bundles of bundles is not a valid case
- This data is not provided in any particular format (e.g. Json or Yaml). 
  - Thus you are not expected to implement parsing, but we do expect you to create the corresponding scriptable objects for the items defined below. 

```
    - Lives
        - Quantity: 5
    - Coins 
        - Quantity: 250
    - Coins 
        - Quantity: 500
    - Cosmetic_1
    - Cosmetic_2 
    - Bundle_1: 
        - Lives
            - Quantity: 3
        - Coins
            - Quantity: 200
        - Cosmetic_1
    - Bundle_2: 
        - Lives
            - Quantity: 1
        - Coins
            - Quantity: 200
        - Cosmetic_1
        - Cosmetic_2
```

## Submission
Approximate working time: ~4 hours

As per our daily working practices, we would like to simulate your code changes as a Pull Request, however with a few modifications:

- Please commit all your changes on a feature branch created from `main` - using whatever naming convention you prefer. 
- Write your Pull Request summary as a file called `PR_SUMMARY.md` and commit this file into the root of your repository. 
    - This should contain the same information you may choose to include on an actual Github Pull Request. 
    - This should help orientate developers who have not been exposed to the brief to understand the code changes you are introducing to the repository.
    - This does not have to be exhaustive, but should help us orientate ourselves to the changes you have made, or any particular strategies or omissions you would like to draw our attention to.
- We would then like you to prepare your commits as git patches, and submit these patches to us in a zip file called `SingKing_CodingTest_YourName_Patches.zip`

### Preparing your Git Patches

Git patches are an old feature that allowed git to be used across mailing lists - or in this case for you to submit your code without us needing to give you access to our GitHub organisation.

Assuming your work has been committed to a branch derived from `main`, you can prepare your patches by running the following command:
```
git format-patch main
```

This will create a patch file for every commit on your branch since it diverged from `main`. All patch files will be created in the root of your directory. Example: 

```
0001-Create-Mock-Service.patch
```

How you structure your commits is at your discretion. Please provide all your patch file(s) in a zip file called `SingKing_CodingTest_YourName_Patches.zip` and submit this file to us. 

When reviewing your code, we will apply these patches to the repository using the command `git am 0001-Create-Mock-Service.patch` (for as many patches as you submit). This will allow us to see your commit messages and simulate a submitted Pull Request. 

### AI Usage

We are primarily interested in evaluating your coding ability, so we recommend you either avoid using AI, or at least only use it in a supporting capacity. However, if you employ agentic AI to generate large portions of your code, we ask that you submit a log of your prompts in a `PROMPTS.md` file committed into the root of the repository, so that we can understand how you used AI in your process. We may also ask you follow-up questions during the in-person interview to verify you thoroughly understand how the generated code works. 

## Evaluation Criteria

The take-home test is one component of our evaluation process. The primary signal we are looking to verify is that your stated experience with Unity is accurate. We expect the majority of candidates to be able to create a working solution and pass this stage, so please don't feel the need over deliver in order to impress us - we value your time and are simply looking for a snapshot of your coding sensibilities. We will ultimately differentiate candidates via the in-person interview, where we can build a holistic picture of your experiences, and explore your approach to problem solving in greater depth.

We will review your code as if it was a Pull Request submitted to our project's git repository. We appreciate that you have not been exposed to our coding standards or our review culture, so we will not make any evaluations on coding style - so long as we can reasonably understand the intent of your code as experienced Unity developers.

What counts as "reasonable" is subjective, but broadly:

- **Can we, without further instruction, understand how to add additional reward items**?
- Did you satisfy the brief?
- Is the intent of your code clear?
- Is your coding style consistent? 
- Is your code organised?
- Can we understand the code's responsibilities?
- Are your git commits well formatted and using good hygiene? 

We may flag additional topics we may seek to discuss in the in-person interview, for example:

- Anti-patterns or code smells that might make future maintenance more difficult.
- Architecture choices that might make it difficult for other developers to onboard with. 

However, on these additional points we will keep your relative Unity experience level in mind.


