



# Master-Mind
This is a Clone of the common Master Mind game designed in Visual Studio using Visual Basic

## Table of Contents 
1. [General Tips and Set up](https://github.com/Gregory-Salley-199/Master-Mind/blob/main/README.md#general-tips-and-set-up)
2. [Playing](https://github.com/Gregory-Salley-199/Master-Mind/blob/main/README.md#playing)
3. [Sequence Diagram](https://github.com/Gregory-Salley-199/Master-Mind/blob/main/README.md#sequence-diagram)
4. [Requirement Analysis](https://github.com/Gregory-Salley-199/Master-Mind/blob/main/README.md#requirement-analysis)
5. [Code Snippet](https://github.com/Gregory-Salley-199/Master-Mind/blob/main/README.md#code-snippet)
6. [License](https://github.com/Gregory-Salley-199/Master-Mind/blob/main/README.md#license)

## General Tips and Set up
Ensure that you have read and understand the Project Proposal before downloading as it gives the list of requirements. 
To run, simply download the package and open it within Visual Studio and once it opens click "run".
This is a simple visual C# game in which a random sequence is made upon start and you have eight (8) tries to get the sequence correct.
While guessing at what the seqence of four pegs (Beginnner), five pegs (Intermediate), and six pegs (Advanced) there is a hint box next to each line in which you have guessed. 
With the hint box there are three types of feedback. Blank being nothing mathces the sequence. A circle being filled in with black meaning that a space is filled in correctly (though it does not give the peg in which you have right). The final option is the circle being filled in red, meaning that the right color is on a peg, but not in the right position (It also does not give the position of which peg it is).

## Playing
![MM-Video-Short](https://user-images.githubusercontent.com/54416040/116465911-7aaeb300-a833-11eb-9f77-804aa4bb0fbc.gif)
See the link including a video playing the game [Gameplay](https://github.com/Gregory-Salley-199/Master-Mind/blob/main/MM%20video.zip) or the above shortened gif!
After selecting a level the pegs will place and adjust accordingly, then start from the bottom and click on one peg to change its color. Continue to click and the colors will cycle through. Once all pegs on the line are selected with a color the "Check" button will no longer be diabled. 

## Sequence Diagram
Below you can view the Sequnce Diagram, or download it here [Sequence Diagram](https://github.com/Gregory-Salley-199/Master-Mind/blob/main/MM%20Sequence%20Diagram.pdf)
![MM Sequence Diagram](https://user-images.githubusercontent.com/54416040/116467098-ecd3c780-a834-11eb-9301-03d58fe35dbf.jpg)

## Requirement Analysis
See the attached file at the following link [Requirement Analysis](https://github.com/Gregory-Salley-199/Master-Mind/blob/main/Master%20Mind%20Clone%20Requirement.docx)
If the Raw does not pop up, it is a simple Word Doc that can be opened in most basic word editors. 

## Code Snippet
<img width="619" alt="MM Code Snippet" src="https://user-images.githubusercontent.com/54416040/116468603-ad0ddf80-a836-11eb-8b8e-0cad867b1a18.png">
The above snippet is a sample of code from my project. This line of code is used to place the the pegs within the game, but also is one of the biggest pains in my side as it effects the size and scalability.

## License
[MIT](https://github.com/Gregory-Salley-199/Master-Mind/blob/main/License)
