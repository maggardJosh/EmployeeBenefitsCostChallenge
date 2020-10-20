import { AppPage } from './app.po';
import { browser, by,  protractor } from 'protractor';


describe('App', () => {
  let page: AppPage;

  beforeEach(() => {
    page = new AppPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getMainHeading()).toEqual('Employees');
  });

});
