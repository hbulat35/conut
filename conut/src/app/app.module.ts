import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppHeaderComponent } from './components/header/app-header.component';
import { AppFooterComponent } from './components/footer/app-footer.component';
import { HttpClientModule } from '@angular/common/http';
import { HomeArticlesCorouselComponent } from './components/home/articles-corousel/articles-corousel.component';
import { HomePageComponent } from './components/home/home.component';
import { SlickCarouselModule } from 'ngx-slick-carousel';
import { HomeArticlesAndNewsComponent } from './components/home/articles-and-news/articles-and-news.component';
import { ArticlePageComponent } from './components/article/article.component';

@NgModule({
  declarations: [
    AppComponent,
    AppHeaderComponent,
    AppFooterComponent,
    HomeArticlesCorouselComponent,
    HomePageComponent,
    HomeArticlesAndNewsComponent,
    ArticlePageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    SlickCarouselModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
