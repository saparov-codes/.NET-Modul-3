using MovieCRUD.Service.DTOs;

namespace MovieCRUD.Service.Service;

public interface IMovieService
{
    Guid AddMovie(MovieDto movieDto);

    MovieDto GetMovieById(Guid id);

    void DeleteMovie(Guid id);

    void UpdateMovie(MovieDto movieDto);

    List<MovieDto> GetAll();

    List<MovieDto> GetAllMoviesByDirector(string director);
    MovieDto GetTopRatedMovie(); // ratingi eng baland film qaytarilsin
    List<MovieDto> GetMoviesReleasedAfterYear(DateTime year); // yilidan keyin chiqqan filmlar qaytarilsin
    MovieDto GetHighestGrossingMovie(); // eng ko'p daromad qilgan film qaytarilsin
    List<MovieDto> SearchMoviesByTitle(string keyword); // titleda keyword qatnashgan filmlar royxati qaytsin
    List<MovieDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes); // davomiyligi min va max oralig'ida bo'lgan filmlar
    long GetTotalBoxOfficeEarningsByDirector(string director); // directorning filmlari qancha daromad qilgani qaytarilsin
    List<MovieDto> GetMoviesSortedByRating(); // baholanish bo'yicha sortlab bering. Kattadan kichikga
    List<MovieDto> GetRecentMovies(DateTime years); // so'nggi yil ichida chiqqan filmlar royxati qaytarilsin.

}