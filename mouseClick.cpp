#include <stdlib.h>	
#include <stdio.h>
#include <GL/glut.h>	

void init(void) {
	glClearColor(0.0, 0.0, 0.0, 0.0);
}

void display(void) {
	glClear(GL_COLOR_BUFFER_BIT);
	glClearColor(0.0, 0.0, 0.0, 0.0);
	glFlush();
}

void mouseProcess(int button, int state, int x, int y) {
	if (button == GLUT_LEFT_BUTTON && state == GLUT_DOWN) {
		printf("왼쪽 클릭 위치 (%d, %d)\n", x, y);
	}
	else if (button == GLUT_RIGHT_BUTTON && state == GLUT_DOWN) {
		printf("오른쪽 클릭 (%d, %d)\n", x, y);
	}
	else if (button == GLUT_MIDDLE_BUTTON && state == GLUT_DOWN) {
		printf("중간 클릭(%d, %d)\n", x, y);
	}
}

void mousePassiveMotion(int x, int y) {
	printf("마우스 위치 (%d, %d) \n", x, y);
}

void mouseActiveMotion(int x, int y) {
	printf("누른 마우스 위치 (%d, %d) \n", x, y);
}

int main(int argc, char** argv) {
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowSize(500, 500);
	glutInitWindowPosition(100, 100);
	glutCreateWindow("Mouse and Keyboard");
	init();
	glutDisplayFunc(display);
	glutMouseFunc(mouseProcess);
	glutMotionFunc(mouseActiveMotion);
	glutPassiveMotionFunc(mousePassiveMotion);
	glutMainLoop();
	return 0;
}