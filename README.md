# editor-vowel-count
A web service which provides the average word length in a provided string.

## Usage
First, build and run the service:

### Docker
- `docker build -t editor-vowel-count .`
- `docker run -p 80:80 editor-vowel-count`

### Directly
- `cd src/VowelCount`
- `dotnet build`
- `dotnet run`

Then open `http://localhost:80/vowel-count?text=your_text_here` in your favourite browser.