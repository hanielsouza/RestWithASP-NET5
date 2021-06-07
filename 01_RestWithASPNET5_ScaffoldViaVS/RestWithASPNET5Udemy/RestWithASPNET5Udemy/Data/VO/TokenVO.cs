namespace RestWithASPNET5Udemy.Data.VO
{
    public class TokenVO
    {
        public TokenVO(bool authenticated, string created, string expiration, string accesToken, string refreshToken)
        {
            Authenticated = authenticated;
            Created = created;
            Expiration = expiration;
            AccesToken = accesToken;
            RefreshToken = refreshToken;
        }

        public bool Authenticated { get; set; }
        public string Created { get; set; }
        public string Expiration { get; set; }
        public string AccesToken { get; set; }
        public string RefreshToken { get; set; }

    }
}
