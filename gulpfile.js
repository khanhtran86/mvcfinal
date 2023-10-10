{
    var gulp = require('gulp');
    var sass = require('gulp-sass');
    var cssmin = require('gulp-cssmin');
    var postcss = require('gulp-postcss');
    var autoprefixer = require('autoprefixer');
    var concat = require('gulp-concat');
    var uglify = require('gulp-uglify');
    var minifyCss = require('gulp-cssnano');
    var pipeline = require('readable-stream').pipeline;

    var paths = {
        scss: "./wwwroot/scss/**/*.scss",
        css: "./wwwrooot/css/",
        minCss: "./wwwroot/css/min/",
        js: "wwwrooot/js/*.js",
        minjs: "wwwroot/js/min/",
        concatCssDest: "./wwwroot/css/site.min.css"
    }

    gulp.task('compress', function () {
        return gulp.src('wwwroot/js/*.js')
            .pipe(uglify())
            .pipe(gulp.dest('wwwroot/build/js'))
    })

    gulp.task('minifyCss', function () {
        return gulp.src('wwwroot/css/*.css')
            .pipe(minifyCss())
            .pipe(gulp.dest('wwwroot/build/css'))
    })
}
