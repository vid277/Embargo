public class UserScore
{
    public string username { get; set; }
    public int score { get; set; }
    public Person(string username, int score)
    {
        this.username = username;
        this.score = score;
    }

    public string getUsername() {
        return username;
    }

    public void setUsername(string username) {
        this.username = username;
    }
    

    public int getScore() {
        return score;
    }

    public void setScore(int score) {
        this.score = score;
    }
}