import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './app.route';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavModule } from './nav/nav.module';
import { GridModule } from '@progress/kendo-angular-grid';
import { HttpClientModule } from '@angular/common/http';
import { BlockUIModule } from 'ng-block-ui';
import { WebApiService } from './core/service/web.api.service';
import { AppConfigModule } from './app.config';
import { FooterComponent } from './footer/footer.component';

@NgModule({
  declarations: [AppComponent, FooterComponent],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes, { onSameUrlNavigation: 'reload' }),
    BrowserAnimationsModule,
    NavModule,
    GridModule,
    HttpClientModule,
    BlockUIModule.forRoot(),
    AppConfigModule,
  ],
  exports: [RouterModule],
  providers: [WebApiService],
  bootstrap: [AppComponent],
})
export class AppModule {}
